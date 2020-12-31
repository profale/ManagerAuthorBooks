using ManagerAuthorBooks.Domain.Entities;
using ManagerAuthorBooks.Domain.Queries.Contracts;
using ManagerAuthorBooks.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ManagerAuthorBooks.Domain.Queries
{
    public class BookQueries : IBookQueries
    {
        private readonly IBookRepository _bookRepository;

        public BookQueries(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public async Task<Books> GetBook(Guid id)
        {
            return await _bookRepository.GetById(id);
        }

        public async Task<IEnumerable<Books>> ListBooks()
        {
            return await _bookRepository.GetAll();
        }
    }
}
