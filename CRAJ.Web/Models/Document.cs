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
        [Display(Name = "Nom")]
        public string NomPersonne { get; set; }
        [Required]
        [Display(Name = "Prenom")]
        public string PrenomPersonne { get; set; }
        [Required]
        [Display(Name = "Genre")]
        public Genre Genre { get; set; }
        [Required]
        [Display(Name = "Date de Naissance")]
        public DateTime DateNaissance { get; set; }
        [Required]
        [Display(Name = "Lieu de Naissance")]
        public string LieuNaissance { get; set; }
        [Required]
        [Display(Name = "Date de Création")]
        public DateTime DateCreation { get; set; }
        [Required]
        [Display(Name = "Lieu de Création")]
        public string LieuCreation { get; set; }
        [Required]
        [Display(Name = "Type de docuement")]
        public string Type { get; set; }


    }
}
