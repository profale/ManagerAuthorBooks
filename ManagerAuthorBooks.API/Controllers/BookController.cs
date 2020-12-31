using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ManagerAuthorBooks.Domain.Commands;
using ManagerAuthorBooks.Domain.Commands.BooksCommands;
using ManagerAuthorBooks.Domain.Handlers;
using ManagerAuthorBooks.Domain.Handlers.Contracts;
using ManagerAuthorBooks.Domain.Queries.Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ManagerAuthorBooks.API.Controllers
{
    [Route("api/books")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly ILogger _logger;
        private readonly IBookQueries _queries;
        public BookController(ILogger<BookController> logger, IBookQueries queries)
        {
            _logger = logger;
            _queries = queries;
        }

        [HttpGet]
        public GenericCommandResult GetAll()
        {
            _logger.LogInformation("Executing api/book to list every books");
            var books = _queries.ListBooks().Result;
            return new GenericCommandResult(true, string.Empty, books);
        }

        [HttpGet("{id:guid}")]
        public GenericCommandResult GetById(Guid id)
        {
            _logger.LogInformation("Executing api/book to return book specificated");
            var book = _queries.GetBook(id).Result;
            if (book == null)
                return new GenericCommandResult(false, "The informed book was not found", string.Empty);

            return new GenericCommandResult(true, string.Empty, book);
        }
        [HttpPost]
        public GenericCommandResult Create([FromBody] CreateBooksCommand command, [FromServices] BooksHandler handler)
        {
            _logger.LogInformation("Executing api/author to post author");
            return (GenericCommandResult)handler.Handle(command);
        }

        [HttpPut]
        public GenericCommandResult Update([FromBody] UpdateBooksCommand command, [FromServices] BooksHandler handler)
        {
            _logger.LogInformation("Executing api/book to update book");
            return (GenericCommandResult)handler.Handle(command);
        }
    }
}
