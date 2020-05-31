using System;
using System.Collections.Generic;
using System.Text;

namespace SaM.BookShelves.Models.ViewModels
{
    public class AddBookViewModel
    {
        public string Id { get; set; }

        public long ISBN { get; set; }

        public string Name { get; set; }

        public string OriginalName { get; set; }

        public string Description { get; set; }

        public int Year { get; set; }

        public string Authors { get; set; }

        public string Publishers { get; set; }

        public string ImageUrl { get; set; }
    }
}
