using ManagerAuthorBooks.Domain.Entities;
using ManagerAuthorBooks.Domain.Repositories;
using ManagerAuthorBooks.Infra.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagerAuthorBooks.Infra.Repositories
{
    public class AuthorRepository : IAuthorRepository
    {
        private readonly Context.DataContext _context;

        public AuthorRepository(Context.DataContext context)
        {
            _context = context;
        }

        public void Create(Author author)
        {
            _context.Add(author);
            _context.SaveChanges();
        }

        public void Update(Author author)
        {
            _context.Update(author);
            _context.SaveChanges();
        }

        public async Task<Author> GetById(Guid id)
        {
            return await _context.Authors.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<Author>> GetAll()
        {
            return await _context.Authors.AsNoTracking().ToListAsync();
        }

    }
}
