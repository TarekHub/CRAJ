using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRAJ.Web.Models
{
    public class Magasin
    {
        public int Id { get; set; }
        public string NomMagasin { get; set; }
        public ConseilJudiciaire ConseilJudiciaire { get; set; }
    }
}
