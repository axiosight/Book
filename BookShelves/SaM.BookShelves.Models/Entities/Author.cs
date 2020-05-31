using System;
using System.Collections.Generic;
using System.Text;

namespace SaM.BookShelves.Models.Entities
{
    public class Author
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public ICollection<BookAuthor> BookAuthors { get; set; }
    }
}
