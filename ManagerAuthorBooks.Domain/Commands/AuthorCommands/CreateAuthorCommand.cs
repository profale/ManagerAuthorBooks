using Flunt.Notifications;
using Flunt.Validations;
using ManagerAuthorBooks.Domain.Commands.BooksCommands;
using ManagerAuthorBooks.Domain.Commands.Contracts;
using ManagerAuthorBooks.Domain.Validated;
using System;
using System.Collections.Generic;
using System.Text;

namespace ManagerAuthorBooks.Domain.Commands.AuthorCommands
{
    public class CreateAuthorCommand : Notifiable, ICommand
    {
        public const string QueueName = "create-author-command-queue";
        public CreateAuthorCommand() { }
        public CreateAuthorCommand(string name, DateTime dateOfBirthday, string document, IEnumerable<CreateBooksCommand> books)
        {
            Name = name;
            DateOfBirthday = dateOfBirthday;
            Document = document;
            Books = books;
        }

        public string Name { get; set; }
        public DateTime DateOfBirthday { get; set; }
        public string Document { get; set; }

        public IEnumerable<CreateBooksCommand> Books { get; set; } = null;

        public void Validate()
        {
            AddNotifications(
                new Contract()
                    .Requires()
                    .HasMinLen(Name, 3, "Name", "O nome deve ter mais de 3 caracteres")
                    .IsFalse(ValidatedDocument.IsValid(Document), "Document", "Número de documento inválido")
                    .IsFalse(ValidatedDateOfBirthday.IsValidDateOfBirthday(DateOfBirthday), "DateOfBirthday", "O author deve possuir idade maior que 30 anos")
           );
        }
        
    }
}
