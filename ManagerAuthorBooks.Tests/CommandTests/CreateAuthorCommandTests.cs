using ManagerAuthorBooks.Domain.Commands.AuthorCommands;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace ManagerAuthorBooks.Tests.CommandTests
{
    [TestClass]
    public class CreateAuthorCommandTests
    {
        private readonly CreateAuthorCommand _invalidCommand = new CreateAuthorCommand("", DateTime.Now, "");
        private readonly CreateAuthorCommand _validCommand = new CreateAuthorCommand("Alessandra Ferreira", new DateTime(1981, 6, 25), "09543237778");

        public CreateAuthorCommandTests()
        {
            _invalidCommand.Validate();
            _validCommand.Validate();
        }

        [TestMethod]
        public void Dado_um_comando_invalido()
        {
            Assert.AreEqual(_invalidCommand.Valid, false);

        }
        [TestMethod]
        public void Dado_um_comando_valido()
        {
            Assert.AreEqual(_validCommand.Valid, true);
        }
    }
}
