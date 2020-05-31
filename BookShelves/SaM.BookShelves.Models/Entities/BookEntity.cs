using System;
using System.Collections.Generic;
using System.Text;

namespace SaM.BookShelves.Models.Entities
{
    public class BookEntity
    {
        public string Id { get; set; }

        public string LibraryId { get; set; }
        public Library Library { get; set; }

        public string AppUserId { get; set; }
        public AppUser AppUser { get; set; }

        public string BookId { get; set; }
        public Book Book { get; set; }

        public string StatusId { get; set; }
        public Status Status { get; set; }
    }
}
