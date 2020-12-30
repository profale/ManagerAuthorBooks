using ManagerAuthorBooks.Domain.Entities;
using ManagerAuthorBooks.Domain.Queries.Contracts;
using ManagerAuthorBooks.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ManagerAuthorBooks.Domain.Queries
{
    public class AuthorQueries : IAuthorQueries
    {
        private readonly IAuthorRepository _authorRepository;

        public AuthorQueries(IAuthorRepository authorRepository)
        {
            _authorRepository = authorRepository;
        }

        public async Task<IEnumerable<Author>> ListAuthors()
        {
            return await _authorRepository.GetAll();
        }

        public async Task<Author> GetAuthor(Guid id)
        {
            return await _authorRepository.GetById(id);
        }
    }
}
