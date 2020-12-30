using ManagerAuthorBooks.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ManagerAuthorBooks.Domain.Repositories
{
    public interface IAuthorRepository
    {
        void Create(Author author);
        void Update(Author author);
        Task<Author> GetById(Guid id);
        Task<IEnumerable<Author>> GetAll();

    }
}
