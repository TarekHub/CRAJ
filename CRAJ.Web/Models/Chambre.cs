using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CRAJ.Web.Models
{
    public class Chambre
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Nom du la Chambre")]
        public string Name { get; set; }
    }
}
