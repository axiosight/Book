using System;
using System.Collections.Generic;
using System.Text;

namespace SaM.BookShelves.Models.ViewModels
{
    public class UserViewModel
    {
        public string UserId { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Mobile { get; set; }
        public int Floor { get; set; }
        public int Room { get; set; }
        public string OfficeId { get; set; }
        public string LibraryId { get; set; }
        public string OfficeName { get; set; }
        public IEnumerable<string> Roles { get; set; }
    }
}