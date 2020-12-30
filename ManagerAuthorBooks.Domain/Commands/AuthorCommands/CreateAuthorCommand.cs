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
        public CreateAuthorCommand(string name, DateTime dateOfBirthday, string document)
        {
            Name = name;
            DateOfBirthday = dateOfBirthday;
            Document = document;
        }

        public string Name { get; set; }
        public DateTime DateOfBirthday { get; set; }
        public string Document { get; set; }

        public IEnumerable<CreateBooksCommand> Books { get; set; }

        public void Validate()
        {
            AddNotifications(
                new Contract()
                    .Requires()
                    .HasMinLen(Name, 3, "Name", "The name must be longer than 3 characters")
                    .IsFalse(!ValidatedDocument.IsValid(Document), "Document", "Number of document is invalid")
                    .IsFalse(!ValidatedDateOfBirthday.IsValidDateOfBirthday(DateOfBirthday), "DateOfBirthday", "The author must be over 30 years old")
           );
        }
        
    }
}
