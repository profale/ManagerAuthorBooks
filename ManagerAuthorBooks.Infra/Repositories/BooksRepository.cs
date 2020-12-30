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
    public class BooksRepository : IBookRepository
    {
        private readonly Context.DataContext _context;

        public BooksRepository(Context.DataContext context)
        {
            _context = context;
        }

        public void Create(Books books)
        {
            _context.Add(books);
            _context.SaveChanges();
        }

        public void Update(Books books)
        {
            _context.Update(books);
            _context.SaveChanges();
        }

        public async Task<Books> GetById(Guid id)
        {
            return await _context.Books.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<Books>> GetAll()
        {
            return await _context.Books.AsNoTracking().ToListAsync();
        }

    }
}
