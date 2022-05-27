using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CRAJ.Web.Models
{
    public class Tribunal
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name="Nom du Tribunal")]
        public string Name { get; set; }
        
        public ConseilJudiciaire ConseilJudiciaire { get; set; }

        public Tribunal()
        {
        }
    }
}
