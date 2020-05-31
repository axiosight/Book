using System;
using System.Collections.Generic;
using System.Text;

namespace SaM.BookShelves.Models.ViewModels
{
    public class BookedEntityViewModel
    {
        public string Id { get; set; }
        public string AppUserId { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }
        public int Floor { get; set; }
        public int Room { get; set; }
        public string UserName { get; set; }
        public string BookId { get; set; }
        public string BookName { get; set; }
        public string StatusId { get; set; }
        public string StatusName { get; set; }
    }
}
