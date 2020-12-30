using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ManagerAuthorBooks.Domain.Commands;
using ManagerAuthorBooks.Domain.Commands.AuthorCommands;
using ManagerAuthorBooks.Domain.Entities;
using ManagerAuthorBooks.Domain.Handlers;
using ManagerAuthorBooks.Domain.Queries;
using ManagerAuthorBooks.Domain.Queries.Contracts;
using ManagerAuthorBooks.Domain.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ManagerAuthorBooks.API.Controllers
{
    [Route("api/authors")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private readonly ILogger _logger;
        private readonly IAuthorQueries _queries;
        public AuthorController(ILogger<AuthorController> logger, IAuthorQueries queries)
        {
            _logger = logger;
            _queries = queries;
        }

        [HttpGet]
        public GenericCommandResult GetAll()
        {
            _logger.LogInformation("Executing api/author to list every authors");
            var authores = _queries.ListAuthors().Result;
            return new GenericCommandResult(true, string.Empty, authores); 
        }

        [HttpGet("{id:guid}")]
        public GenericCommandResult GetById(Guid id)
        {
            _logger.LogInformation("Executing api/author to return author specificated");
            var author = _queries.GetAuthor(id).Result;
            if (author == null)
                return new GenericCommandResult(false, "The informed author was not found", string.Empty);

            return new GenericCommandResult(true, string.Empty, author);
        }

        [HttpPost]
        public GenericCommandResult Create([FromBody] CreateAuthorCommand command, [FromServices] AuthorHandler handler)
        {
            _logger.LogInformation("Executing api/author to post author");
            return (GenericCommandResult)handler.Handle(command);
        }

        [HttpPut]
        public GenericCommandResult Update([FromBody] UpdateAuthorCommand command, [FromServices] AuthorHandler handler)
        {
            _logger.LogInformation("Executing api/author to update author");
            return (GenericCommandResult)handler.Handle(command);
        }
    }
}
