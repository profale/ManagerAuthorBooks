using Flunt.Notifications;
using Flunt.Validations;
using ManagerAuthorBooks.Domain.Commands.AuthorCommands;
using ManagerAuthorBooks.Domain.Commands.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace ManagerAuthorBooks.Domain.Commands.BooksCommands
{
    public class CreateBooksCommand : Notifiable, ICommand 
    {
        public const string QueueName = "create-books-command-queue";
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
                .HasMinLen(Title, 3, "Title", "O título deve possuir acima de 3 caracteres")
                .IsFalse(IsValidISBN(ISBN), "ISBN", "ISBN inválido")
                );
        }

        private bool IsValidISBN(string isbn)
        {
            var regex = new Regex(@"^\d{3}\-\d{2}\-\d{3}-\d{4}-\d{1}$");

            if (regex.IsMatch(isbn.ToString()))
            {
                return true;
            }

            return false;
        }
    }
}
