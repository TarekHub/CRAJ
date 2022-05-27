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

        public Tribunal Tribunal { get; set; }


        public Chambre Chambre { get; set; }

        [Display(Name = "Type de Docuement")]
        public TypeDoc TypeDocuement { get; set; }

        public int TypeArchive { get; set; }

        [Column(TypeName = "varchar(max)")]
        public byte[] DocumentImage { get; set; }

        public bool isInTribunal { get; set; }
        public bool isInConseilJ { get; set; }
        public bool isInArchived { get; set; }
        public bool isInProgress { get; set; }


    }
}
