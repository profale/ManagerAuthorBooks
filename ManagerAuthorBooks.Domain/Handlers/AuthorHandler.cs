using AutoMapper;
using Flunt.Notifications;
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
        private IMediatorHandler bus;
        private readonly IMapper _mapper;
        

        public AuthorHandler(IAuthorRepository authorRepository)
        {
            _authorRepository = authorRepository;
        }

        public ICommandResult Handle(CreateAuthorCommand command)
        {
            //FAIL FAST VALIDATION
            command.Validate();
            if (command.Invalid)
                return new GenericCommandResult(false, "Ocorreu um erro ao salvar o registro solicitado", command.Notifications);

            var mapAuthor = _mapper.Map<CreateAuthorCommand, Author>(command);
            //Gerar o Author
            var author = new Author(mapAuthor.Name, mapAuthor.DateOfBirthday, mapAuthor.Document, mapAuthor.Books);

            //Salvar no banco
            _authorRepository.Create(author);

            //enviar mensagem para fila
            bus.Enqueue(command, CreateAuthorCommand.QueueName);

            return new GenericCommandResult(true, "O Author foi salvo com sucesso", author);
        }

        public ICommandResult Handle(UpdateAuthorCommand command)
        {
            //FAIL FAST VALIDATION
            command.Validate();
            if (command.Invalid)
                return new GenericCommandResult(false, "Ocorreu um erro ao atualizar o registro solicitado", command.Notifications);

            //Recuperar Author do Banco
            var author = _authorRepository.GetById(command.Id);

            var mapAuthor = _mapper.Map<UpdateAuthorCommand, Author>(command);
            
            //Atualizar os dados no banco
            author.UpdateAuthor(mapAuthor.Id, mapAuthor.Name, mapAuthor.DateOfBirthday, mapAuthor.Document, mapAuthor.Books);

            //Salvar no banco
            _authorRepository.Update(author);

            //Enviar mensagem para fila
            bus.Enqueue(command, UpdateAuthorCommand.QueueName);

            return new GenericCommandResult(true, "O Author foi atualizado com sucesso", author);
        }

        
    }
}
