using ManagerAuthorBooks.Domain.Entities;
using ManagerAuthorBooks.Domain.Repositories;
using ManagerAuthorBooks.Infra.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ManagerAuthorBooks.Tests.Repositories
{
    public class FakeAuthorRepository : IAuthorRepository
    {
        private readonly DataContext _context;

        public FakeAuthorRepository(DataContext context)
        {
            _context = context;
        }

        public void Create(Author author)
        {
            
        }

        public void Update(Author author)
        {
            
        }

        //public Author GetById(Guid id)
        //{
        //    return new Author("Novo nome", new DateTime(1981, 06, 25), "095432337778", null);
        //}

        public async Task<Author> GetById(Guid id)
        {
            return await _context.Authors.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<Author>> GetAll()
        {
           return await _context.Authors.ToListAsync();

        }

       
    }
}
