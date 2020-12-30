using Flunt.Notifications;
using Flunt.Validations;
using ManagerAuthorBooks.Domain.Commands.AuthorCommands;
using ManagerAuthorBooks.Domain.Commands.Contracts;
using ManagerAuthorBooks.Domain.Validated;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace ManagerAuthorBooks.Domain.Commands.BooksCommands
{
    public class CreateBooksCommand : Notifiable, ICommand 
    {
        public const string QueueName = "create-books-command-queue";
        public CreateBooksCommand() {}

        public CreateBooksCommand(string title, DateTime releaseDate, string iSBN, string category, CreateAuthorCommand author)
        {
            Title = title;
            ReleaseDate = releaseDate;
            ISBN = iSBN;
            Category = category;
            Author = author;
        }

        public string Title { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string ISBN { get; set; }
        public string Category { get; set; }
        public CreateAuthorCommand Author { get; set; }

        public void Validate()
        {
            AddNotifications(
                new Contract()
                .Requires()
                .HasMinLen(Title, 3, "Title", "The title must be over 3 characters")
                .IsFalse(!ValidatedISBN.IsValidISBN(ISBN), "ISBN", "ISBN invalid")
                );
        }

    }
}
