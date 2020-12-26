using ManagerAuthorBooks.Domain.Commands.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace ManagerAuthorBooks.Domain.Handlers.Contracts
{
    public interface IHandler<T> where T : ICommand
    {
        ICommandResult Handle(T command);
    }
}
