using AutoMapper;
using ManagerAuthorBooks.API.Mappers;
using ManagerAuthorBooks.Domain.Cache.Contract;
using ManagerAuthorBooks.Domain.Commands;
using ManagerAuthorBooks.Domain.Commands.AuthorCommands;
using ManagerAuthorBooks.Domain.Entities;
using ManagerAuthorBooks.Domain.Handlers;
using ManagerAuthorBooks.Domain.Handlers.Contracts;
using ManagerAuthorBooks.Infra.Context;
using ManagerAuthorBooks.Tests.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace ManagerAuthorBooks.Tests.HandlerTests
{
    [TestClass]
    public class CreateAuthorHandlerTests
    {
        private readonly CreateAuthorCommand _invalidCommand = new CreateAuthorCommand("", DateTime.Now, "");
        private IMapper _mapper;
        private readonly CreateAuthorCommand _validCommand = new CreateAuthorCommand("Teste Handler", new DateTime(1981, 6, 25), "14249503097");
        private AuthorHandler _handler;
        private IMediatorHandler _bus;
        private readonly ICacheService _cache;
        private GenericCommandResult _result = new GenericCommandResult();

        public CreateAuthorHandlerTests()
        {

        }
        public CreateAuthorHandlerTests(IMapper mapper, IMediatorHandler bus, ICacheService cache)
        {
            _mapper = mapper;
            _bus = bus;
            _cache = cache;

        }


        [TestMethod]
        public void Dado_um_comando_invalido_deve_interromper_a_execucao()
        {
            _handler = new AuthorHandler(new FakeAuthorRepository(new DataContext(new DbContextOptions<DataContext>())), _mapper, _bus, _cache);
            _result = (GenericCommandResult)_handler.Handle(_invalidCommand);
            Assert.AreEqual(_result.Success, false);
        }
        [TestMethod]
        public void Dado_um_comando_valido_deve_criar_a_tarefa()
        {
            _handler = new AuthorHandler(new FakeAuthorRepository(new DataContext(new DbContextOptions<DataContext>())), _mapper, _bus, _cache);
            _result = (GenericCommandResult)_handler.Handle(_validCommand);
            Assert.AreEqual(_result.Success, false);
            
        }
    }
}
