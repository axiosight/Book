using System;
using System.Collections.Generic;
using System.Text;

namespace SaM.BookShelves.Models.Entities
{
    public class Book
    {
        public string Id { get; set; }

        public long ISBN { get; set; }

        public string Name { get; set; }

        public string OriginalName { get; set; }

        public string Description { get; set; }

        public int Year { get; set; }

        public ICollection<BookEntity> BookEntities { get; set; }

        public ICollection<BookPublisher> BookPublishers { get; set; }

        public ICollection<BookTag> BookTags { get; set; }

        public ICollection<BookAuthor> BookAuthors { get; set; }

        public ICollection<Preview> Previews { get; set; }
    }
}
