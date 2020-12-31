using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ManagerAuthorBooks.Domain.Entities
{
    public class Author : Entity
    {
        public Author()
        {
        }
        public Author(string name, DateTime dateOfBirthday, string document)
        {
            Name = name;
            DateOfBirthday = dateOfBirthday;
            Document = document;
        }

        public string Name { get; set; }
        public DateTime DateOfBirthday { get; set; }
        public string Document { get; set; }

        public IEnumerable<Books> Books { get; set; }

        public void UpdateAuthor(Guid id, string name, DateTime dateOfBirthday, string document)
        {
            Id = id;
            Name = name;
            DateOfBirthday = dateOfBirthday;
            Document = document;
        }
    }
}
