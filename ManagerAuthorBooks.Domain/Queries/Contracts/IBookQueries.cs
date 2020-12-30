using ManagerAuthorBooks.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ManagerAuthorBooks.Domain.Queries.Contracts
{
    public interface IBookQueries
    {
        Task<Books> GetBook(Guid id);
        Task<IEnumerable<Books>> ListBooks();
    }
}
