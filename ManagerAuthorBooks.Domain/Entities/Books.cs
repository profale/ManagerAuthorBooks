using System;
using System.Collections.Generic;
using System.Text;

namespace ManagerAuthorBooks.Domain.Entities
{
    public class Books : Entity
    {
        public Books() { }
        public Books(string title, DateTime releaseDate, string isbn, string category, Author author)
        {
            Title = title;
            ReleaseDate = releaseDate;
            ISBN = isbn;
            Category = category;
            Author = author;
        }

        public string Title { get; private set; }
        public DateTime ReleaseDate { get; private set; }
        public string ISBN { get; private set; }
        public string Category { get; private set; }
        public Author Author { get; private set; }

    }
}
