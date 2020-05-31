using System;
using System.Collections.Generic;
using System.Text;

namespace SaM.BookShelves.Models.Entities
{
    public class BookTag
    {
        public string BookId { get; set; }
        public Book Book { get; set; }

        public string TagId { get; set; }
        public Tag Tag { get; set; }
    }
}
