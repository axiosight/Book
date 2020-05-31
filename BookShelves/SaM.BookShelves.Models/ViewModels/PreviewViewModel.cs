using System;
using System.Collections.Generic;
using System.Text;

namespace SaM.BookShelves.Models.ViewModels
{
    public class PreviewViewModel
    {
        public string Id { get; set; }

        public byte[] Img { get; set; }

        public string ImgUrl { get; set; }

        public string Name { get; set; }

        public string Extension { get; set; }

        public string Type { get; set; }

        public bool IsPreview { get; set; }

        public string BookId { get; set; }
    }
}
