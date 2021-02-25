using ManagerAuthorBooks.Domain.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace ManagerAuthorBooks.Tests
{
    [TestClass]
    public class AuthorQueriesTests
    {
        private IList<Author> _authores;

        public AuthorQueriesTests()
        {
            _authores = new List<Author>();
            _authores.Add(new Author("Clara", new DateTime(1981, 06, 25), "26416727072"));
            _authores.Add(new Author("Jose", new DateTime(1979, 08, 06), "31554744083"));
            _authores.Add(new Author("Cristina", new DateTime(1956, 01, 01), "35506596014"));
            _authores.Add(new Author("Paulo", new DateTime(1953, 09, 17), "69390977088"));
            _authores.Add(new Author("Andre", new DateTime(1967, 03, 15), "48973957040"));
        }

        [TestMethod]
        [TestCategory("Queries")]
        public void Deve_retornar_uma_lista_de_authores()
        {
            Assert.IsTrue(_authores.Count > 0);
        }
    }
}
