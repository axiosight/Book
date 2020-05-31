using System;
using System.Collections.Generic;
using System.Text;

namespace SaM.BookShelves.Models.Entities
{
    public class BookPublisher
    {
        public string BookId { get; set; }
        public Book Book { get; set; }

        public string PublisherId { get; set; }
        public Publisher Publisher { get; set; }
    }
}
