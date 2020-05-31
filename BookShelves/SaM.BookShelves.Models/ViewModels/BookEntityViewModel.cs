using System;
using System.Collections.Generic;
using System.Text;

namespace SaM.BookShelves.Models.ViewModels
{
    public class BookEntityViewModel
    {
        public string Id { get; set; }

        public string LibraryId { get; set; }

        public string AppUserId { get; set; }

        public string BookId { get; set; }

        public string StatusId { get; set; }
    }
}