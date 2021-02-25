using ManagerAuthorBooks.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ManagerAuthorBooks.Domain.Repositories.MongoDB
{
    public interface IBookMongoRepository
    {
        bool Add(Books books);
        Task<bool> AddAsync(Books books);
        bool Update(Author author);
        Task<bool> UpdateAsync(Books books);
        bool Remove(Books books);
        Task<bool> RemoveAsync(Books books);
        List<Author> GetAll();
        Task<Author> GetAllAsync();
        Author Get(Guid id);
        Task<Author> GetAsync(Guid id);
    }
}
