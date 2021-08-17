using System.ComponentModel.DataAnnotations;

namespace DataLayer.Entities
{
    public class Author
    {
        [Required]
        [Display(Name = "Name")]
        [MaxLength(50)]
        public string Name { get; set; }
        [MaxLength(50)]
        [Display(Name = "Surname")]
        public string Surname { get; set; }          
        public string Email { get; set; }
    }
}