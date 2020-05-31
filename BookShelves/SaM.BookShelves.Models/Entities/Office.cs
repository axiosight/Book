using System;
using System.Collections.Generic;
using System.Text;

namespace SaM.BookShelves.Models.Entities
{
    public class Office
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string Adress { get; set; }

        public ICollection<Library> Libraries { get; set; }

        public ICollection<AppUser> AppUsers { get; set; }
    }
}
