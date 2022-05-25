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
    public class DocumentsModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        public IEnumerable<Document> Documents { get; set; }
        public DocumentsModel(ApplicationDbContext context)
        {
            _context = context;
        }
        public void OnGet()
        {
            Documents = _context.Document;
        }
    }
}
