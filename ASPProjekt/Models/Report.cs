using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace ASPProjekt.Models
{
    public class Report
    {
        [Key]
        public int IdRaport { get; set; }
        [Required]

        public string Topic { get; set; }
        public string Environment { get; set; }
        public string Description { get; set; }

        public string status { get; set; }
        


    }
}
