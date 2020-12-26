using ManagerAuthorBooks.Domain.Entities;
using ManagerAuthorBooks.Domain.Repositories;
using ManagerAuthorBooks.Infra.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ManagerAuthorBooks.Infra.Repositories
{
    public class AuthorRepository : IAuthorRepository
    {
        private readonly DataContext _context;

        public AuthorRepository(DataContext context)
        {
            _context = context;
        }

        public void Create(Author author)
        {
            _context.Add(author);
        }

        public void Update(Author author)
        {
            _context.Update(author);
        }

        public Author GetById(Guid id)
        {
            return _context.Authors.Find(id);
        }
    }
}
