using CRAJ.Web.Types;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CRAJ.Web.Models
{
    public class Document
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Identifiant de la personne")]
        public int IdPersonne { get; set; }

        [Required]
        [Display(Name = "Date")]
        public DateTime DateCreation { get; set; }

        [Required]
        [Display(Name = "Lieu")]
        public string LieuCreation { get; set; }


    }
}
