using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CRAJ.Web.Data;
using CRAJ.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace CRAJ.Web.Pages.Account
{
    public class ArchDocumentsModel : PageModel
    {
        private readonly ApplicationDbContext _dbContext;
        public IEnumerable<Document> Documents { get; set; }

        public ArchDocumentsModel(ApplicationDbContext applicationDbContext)
        {
            _dbContext = applicationDbContext;
        }

        public async Task OnGet(int conseilId)
        {
            Documents = await _dbContext.Document.Where(d => d.isInArchived == true && d.Tribunal.ConseilJudiciaire.Id==conseilId)
            .Include(d => d.Tribunal).ThenInclude(t => t.ConseilJudiciaire)
            .Include(d => d.Chambre).Include(d => d.TypeDocuement).ToListAsync();

        }

        public FileResult OnGetDownloadFileFromDatabase(string fileName)
        {
            var bytes = _dbContext.Document.Where(d => "Document_" + d.TypeDocuement.Nom + "_" + d.Id.ToString() == fileName).SingleOrDefault()
                .DocumentImage;

            //Send the File to Download.
            return File(bytes, "application/octet-stream", fileName + ".png");
        }
    }
}
