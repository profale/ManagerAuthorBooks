using ManagerAuthorBooks.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ManagerAuthorBooks.Domain.Repositories
{
    public interface IAuthorRepository
    {
        void Create(Author author);
        void Update(Author author);
        Author GetById(Guid id);
    }
}
