using ManagerAuthorBooks.Domain.Commands;
using ManagerAuthorBooks.Domain.Commands.AuthorCommands;
using ManagerAuthorBooks.Domain.Handlers;
using ManagerAuthorBooks.Tests.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace ManagerAuthorBooks.Tests.HandlerTests
{
    [TestClass]
    public class CreateAuthorHandlerTests
    {
        private readonly CreateAuthorCommand _invalidCommand = new CreateAuthorCommand("", DateTime.Now, "", null);
        private readonly CreateAuthorCommand _validCommand = new CreateAuthorCommand("Alessandra Ferreira", new DateTime(1981, 6, 25), "09543237778", null);
        private readonly AuthorHandler _handler = new AuthorHandler(new FakeAuthorRepository());
        private GenericCommandResult _result = new GenericCommandResult();

        [TestMethod]
        public void Dado_um_comando_invalido_deve_interromper_a_execucao()
        {
            _result = (GenericCommandResult)_handler.Handle(_invalidCommand);
            Assert.AreEqual(_result.Success, false);
        }
        [TestMethod]
        public void Dado_um_comando_invalido_deve_criar_a_tarefa()
        {

            _result = (GenericCommandResult)_handler.Handle(_validCommand);
            Assert.AreEqual(_result.Success, false);
            
        }
    }
}
