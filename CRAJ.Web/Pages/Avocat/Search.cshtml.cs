using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CRAJ.Web.Data;
using CRAJ.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace CRAJ.Web.Pages.Avocat
{
    public class SearchModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        [BindProperty(SupportsGet =true)]
        public string SearchTerm { get; set; }
        public IEnumerable<Document> Documents  { get; set; }

        public SearchModel(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task OnGet()
        {
            Documents = await _context.Document.Where(d=>d.Code == SearchTerm)
                .Include(d => d.Tribunal).ThenInclude(t => t.ConseilJudiciaire)
                .Include(d => d.Chambre).Include(d => d.TypeDocuement).ToListAsync();
        }

        public FileResult OnGetDownloadFileFromDatabase(string fileName)
        {
            var bytes = _context.Document.Where(d => "Document_" + d.TypeDocuement.Nom + "_" + d.Id.ToString() == fileName).SingleOrDefault()
                .DocumentImage;

            //Send the File to Download.
            return File(bytes, "application/octet-stream", fileName + ".png");
        }
    }
}
