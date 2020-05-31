using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SaM.BookShelves.Models.ViewModels
{
    public class BookViewModel
    {
        public string Id { get; set; }

        public long ISBN { get; set; }

        public string Name { get; set; }

        public string OriginalName { get; set; }

        public string Description { get; set; }

        public int Year { get; set; }

        public IEnumerable<TagViewModel> TagViewModels { get; set; } 

        public IEnumerable<AuthorViewModel> AuthorViewModels { get; set; } 

        public IEnumerable<PublisherViewModel> PublisherViewModels { get; set; } 

        public IEnumerable<BookEntityViewModel> BookEntityViewModels { get; set; } 

        public PreviewViewModel PreviewViewModelMain { get; set; }
    }
}
