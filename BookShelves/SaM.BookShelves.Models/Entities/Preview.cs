using System;
using System.Collections.Generic;
using System.Text;

namespace SaM.BookShelves.Models.Entities
{
    public class Preview
    {
        public string Id { get; set; }

        public byte[] Img { get; set; }

        public string Name { get; set; }

        public string Extension { get; set; }

        public string Type { get; set; }

        public bool IsPreview { get; set; }

        public string BookId { get; set; }
        public Book Book { get; set; }
    }
}
