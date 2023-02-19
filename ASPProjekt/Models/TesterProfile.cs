using System.ComponentModel.DataAnnotations;

namespace ASPProjekt.Models
{
    public class TesterProfile
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Surname { get; set; }
        
    }
}
