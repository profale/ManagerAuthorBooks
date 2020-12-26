using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ManagerAuthorBooks.Domain.Handlers.Contracts
{
    public interface IMediatorHandler
    {
        void Enqueue<T>(T command, string queueName);
    }
}
