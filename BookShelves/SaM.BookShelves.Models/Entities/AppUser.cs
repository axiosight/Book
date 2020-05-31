using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace SaM.BookShelves.Models.Entities
{
    public class AppUser : IdentityUser
    {
        public string AppUserName { get; set; }

        public string Surname { get; set; }

        public int Floor { get; set; }

        public int Room { get; set; }

        public string OfficeId { get; set; }
        public Office Office { get; set; }

        public string LibraryId { get; set; }
        public Library Library { get; set; }

        public ICollection<BookEntity> BookEntities { get; set; }
    }
}
