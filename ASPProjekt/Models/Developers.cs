using System.ComponentModel.DataAnnotations;

namespace ASPProjekt.Models
{
    public class Developers
    {
        [Key]
        public int IdDevelopers { get; set; }
        [Required]
        public string Name { get; set; }
        public string Surname { get; set; }
    }
}
