using Flunt.Notifications;
using Flunt.Validations;
using ManagerAuthorBooks.Domain.Commands.AuthorCommands;
using ManagerAuthorBooks.Domain.Commands.Contracts;
using ManagerAuthorBooks.Domain.Validated;
using System;
using System.Collections.Generic;
using System.Text;

namespace ManagerAuthorBooks.Domain.Commands.BooksCommands
{
    public class UpdateBooksCommand : Notifiable, ICommand
    {
        public const string QueueName = "update-books-command-queue";

        public UpdateBooksCommand() { }

        public UpdateBooksCommand(Guid id, string title, DateTime releaseDate, string iSBN, string category, UpdateAuthorCommand author)
        {
            Id = id;
            Title = title;
            ReleaseDate = releaseDate;
            ISBN = iSBN;
            Category = category;
            Author = author;
        }

        public Guid Id { get; set; }
        public string Title { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string ISBN { get; set; }
        public string Category { get; set; }
        public UpdateAuthorCommand Author { get; set; }
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
