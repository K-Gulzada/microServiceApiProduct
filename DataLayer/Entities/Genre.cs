using System;
using System.ComponentModel.DataAnnotations;

namespace DataLayer.Entities
{
    public class Genre
    {      
        public string GenreCode { get { return Guid.NewGuid().ToString(); } }
        public string GenreName { get; set; }
    }
}