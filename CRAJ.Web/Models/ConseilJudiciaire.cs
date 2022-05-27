using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CRAJ.Web.Models
{
    public class ConseilJudiciaire
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Display(Name = "Nom du Conseil")]
        public string Name { get; set; }


        public ICollection<Tribunal> Tribunal { get; set; }
    }
}
