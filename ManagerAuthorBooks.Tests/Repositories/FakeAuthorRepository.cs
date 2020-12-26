using ManagerAuthorBooks.Domain.Entities;
using ManagerAuthorBooks.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace ManagerAuthorBooks.Tests.Repositories
{
    public class FakeAuthorRepository : IAuthorRepository
    {
        public void Create(Author author)
        {
            
        }

        public void Update(Author author)
        {
            
        }

        public Author GetById(Guid id)
        {
            return new Author("Novo nome", new DateTime(1981, 06, 25), "095432337778", null);
        }
    }
}
