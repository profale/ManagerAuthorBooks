using Flunt.Notifications;
using ManagerAuthorBooks.Domain.Commands.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace ManagerAuthorBooks.Domain.Commands.BooksCommands
{
    public class UpdateBooksCommand : Notifiable, ICommand
    {
        public void Validate()
        {
            throw new NotImplementedException();
        }
    }
}
