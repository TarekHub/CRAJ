using CRAJ.Web.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRAJ.Web.Data
{
    public class ApplicationUser : IdentityUser
    {
        public int IdUser { get; set; }
        public ConseilJudiciaire ConseilJudiciaire { get; set; }
        public Tribunal Tribunal{ get; set; }
        public Chambre Chambre{ get; set; }
    }
}
