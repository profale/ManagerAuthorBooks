using AutoMapper;
using Flunt.Notifications;
using ManagerAuthorBooks.Domain.Commands;
using ManagerAuthorBooks.Domain.Commands.BooksCommands;
using ManagerAuthorBooks.Domain.Commands.Contracts;
using ManagerAuthorBooks.Domain.Entities;
using ManagerAuthorBooks.Domain.Handlers.Contracts;
using ManagerAuthorBooks.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace ManagerAuthorBooks.Domain.Handlers
{
    public class BooksHandler : Notifiable,
        IHandler<CreateBooksCommand>,
        IHandler<UpdateBooksCommand>

    {
        private readonly IBookRepository _bookRepository;
        private IMediatorHandler _bus;
        private readonly IMapper _mapper;

        public BooksHandler(IBookRepository bookRepository, IMediatorHandler bus, IMapper mapper)
        {
            _bookRepository = bookRepository;
            _bus = bus;
            _mapper = mapper;
        }

        public ICommandResult Handle(CreateBooksCommand command)
        {
            //FAIL FAST VALIDATION
            command.Validate();
            if (command.Invalid)
                return new GenericCommandResult(false, "An error occurred while saving the requested record", command.Notifications);

            var book = _mapper.Map<CreateBooksCommand, Books>(command);

            //Save the base
            _bookRepository.Create(book);

            //Send message to queue
            _bus.Enqueue(command, CreateBooksCommand.QueueName);

            return new GenericCommandResult(true, $"The Book {book.Title} was save with success", book);
        }

        public ICommandResult Handle(UpdateBooksCommand command)
        {
            //FAIL FAST VALIDATION
            command.Validate();
            if (command.Invalid)
                return new GenericCommandResult(false, "An error occurred while updating the requested record", command.Notifications);

            //Retrieve Author from Database
            var book = _bookRepository.GetById(command.Id).Result;

            var bookUpdate = _mapper.Map<UpdateBooksCommand, Books>(command);

            //Update the data in the database
            book.UpdateBook(bookUpdate.Title, bookUpdate.ReleaseDate, bookUpdate.ISBN, bookUpdate.Category, bookUpdate.AuthorId);

            _bookRepository.Update(book);

            //Send message to queue
            _bus.Enqueue(command, UpdateBooksCommand.QueueName);

            return new GenericCommandResult(true, $"The book {book.Title} has been updated successfully", book);
        }
    }
}
