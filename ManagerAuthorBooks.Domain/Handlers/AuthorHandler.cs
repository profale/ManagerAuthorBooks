using AutoMapper;
using Flunt.Notifications;
using ManagerAuthorBooks.Domain.Cache.Contract;
using ManagerAuthorBooks.Domain.Commands;
using ManagerAuthorBooks.Domain.Commands.AuthorCommands;
using ManagerAuthorBooks.Domain.Commands.Contracts;
using ManagerAuthorBooks.Domain.Entities;
using ManagerAuthorBooks.Domain.Handlers.Contracts;
using ManagerAuthorBooks.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ManagerAuthorBooks.Domain.Handlers
{
    public class AuthorHandler : Notifiable,
        IHandler<CreateAuthorCommand>,
        IHandler<UpdateAuthorCommand>
    {
        private readonly IAuthorRepository _authorRepository;
        private IMediatorHandler _bus;
        private readonly IMapper _mapper;
        private readonly ICacheService _cache;
        private const string key_author = "Author:{id}";


        public AuthorHandler(IAuthorRepository authorRepository, IMapper mapper, IMediatorHandler bus, ICacheService cache)
        {
            _authorRepository = authorRepository;
            _mapper = mapper;
            _bus = bus;
            _cache = cache;
        }

        public ICommandResult Handle(CreateAuthorCommand command)
        {
            //FAIL FAST VALIDATION
            command.Validate();
            if (command.Invalid)
                return new GenericCommandResult(false, "An error occurred while saving the requested record", command.Notifications);

            var author = _mapper.Map<CreateAuthorCommand,Author>(command);
                    
            //Save the Database
            _authorRepository.Create(author);

            //Send message to queue
            _bus.Enqueue(command, CreateAuthorCommand.QueueName);

            //Cache
            var key = key_author.Replace("{id}", author.Id.ToString());

            _cache.Save(command, key);

            return new GenericCommandResult(true, $"The Author {author.Name} was save with success", author);
        }

        public ICommandResult Handle(UpdateAuthorCommand command)
        {
            //FAIL FAST VALIDATION
            command.Validate();
            if (command.Invalid)
                return new GenericCommandResult(false, "An error occurred while updating the requested record", command.Notifications);

            //Retrieve Author from Database
            var author = _authorRepository.GetById(command.Id).Result;

            var mapAuthor = _mapper.Map<UpdateAuthorCommand, Author>(command);

            //Update the data in the database
            author.UpdateAuthor(mapAuthor.Id, mapAuthor.Name, mapAuthor.DateOfBirthday, mapAuthor.Document);

            _authorRepository.Update(author);

            //Send message to queue
            _bus.Enqueue(command, UpdateAuthorCommand.QueueName);

            //Cache
            var key = key_author.Replace("{id}", author.Id.ToString());

            _cache.Save(author, key);

            return new GenericCommandResult(true, $"The author {author.Name} has been updated successfully", author);
        }
    }
}
