using ManagerAuthorBooks.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ManagerAuthorBooks.Domain.Repositories.MongoDB
{
    public interface IAuthorMongoRepository
    {
        bool Add(Author author);
        Task<bool> AddAsync(Author author);
        bool Update(Author author);
        Task<bool> UpdateAsync(Author author);
        bool Remove(Author author);
        Task<bool> RemoveAsync(Author author);
        List<Author> GetAll();
        Task<List<Author>> GetAllAsync();
        Author Get(Guid id);
        Task<Author> GetAsync(Guid id);
    }
}
