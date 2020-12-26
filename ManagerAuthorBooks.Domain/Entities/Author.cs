using System;
using System.Collections.Generic;
using System.Text;

namespace ManagerAuthorBooks.Domain.Entities
{
    public class Author: Entity
    {
        public Author(string name, DateTime dateOfBirthday, string document, IEnumerable<Books> books)
        {
            Name = name;
            DateOfBirthday = dateOfBirthday;
            Document = document;
            Books = books;
        }

        public string Name { get; private set; }
        public DateTime DateOfBirthday { get; private set; }
        public string Document { get; private set; }

        public IEnumerable<Books> Books { get; private set; }

        public void UpdateAuthor(Guid id, string name, DateTime dateOfBirthday, string document, IEnumerable<Books> books)
        { 
            Name = name;
            DateOfBirthday = dateOfBirthday;
            Document = document;
            Books = books;
        }
    }
}
