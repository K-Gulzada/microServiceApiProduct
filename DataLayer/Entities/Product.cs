using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataLayer.Entities
{
    public class Product
    {
        public string Code { get { return Guid.NewGuid().ToString(); } }
        public string ProductName { get; set; }
        public string Description { get; set; }
        public DateTime ReleaseDate { get; set; }
        public Author Author { get; set; }
        public List<Genre> Genres { get; set; }

    }
}
