using System;
using System.Collections.Generic;
using System.Text;

namespace SaM.BookShelves.Models.Entities
{
    public class Status
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public ICollection<BookEntity> BookEntities { get; set; }
    }
}
