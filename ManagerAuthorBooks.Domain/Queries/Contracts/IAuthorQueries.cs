using ManagerAuthorBooks.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ManagerAuthorBooks.Domain.Queries.Contracts
{
    public interface IAuthorQueries
    {
        Task<Author> GetAuthor(Guid id);
        Task<IEnumerable<Author>> ListAuthors();
    }
}
