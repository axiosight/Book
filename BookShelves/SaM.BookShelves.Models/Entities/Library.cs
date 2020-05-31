using System;
using System.Collections.Generic;
using System.Text;

namespace SaM.BookShelves.Models.Entities
{
    public class Library
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public int Floor { get; set; }

        public string OfficeId { get; set; }
        public Office Office { get; set; }

        public ICollection<AppUser> AppUsers { get; set; }

        public ICollection<BookEntity> BookEntities { get; set; }
    }
}
