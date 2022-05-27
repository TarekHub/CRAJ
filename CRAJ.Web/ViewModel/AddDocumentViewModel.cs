using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CRAJ.Web.ViewModel
{
    public class AddDocumentViewModel
    {
        [Required]
        public int IdPersonne { get; set; }
        [Required]
        public int IdTypeDoc { get; set; }
        [Required]
        public int TypeArchive { get; set; }
        [Required]
        public IFormFile FormDocument { get; set; }
    }
}
