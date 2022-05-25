using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CRAJ.Web.Data;
using CRAJ.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CRAJ.Web.Pages.Account
{
    [Authorize]
    public class ImprimerModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        public ImprimerModel(ApplicationDbContext context)
        {
            _context = context;
        }
        public Document Document { get; set; }

        public void OnGet(int id)
        {
            Document = _context.Document.SingleOrDefault(d=>d.Id==id);
        }

        public void Imprimer()
        {

        }
    }
}
