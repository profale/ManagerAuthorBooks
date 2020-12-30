using ManagerAuthorBooks.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ManagerAuthorBooks.Domain.Repositories
{
    public interface IBookRepository
    {
        void Create(Books books);
        void Update(Books books);
        Task<Books> GetById(Guid id);
        Task<IEnumerable<Books>> GetAll();
    }
}
