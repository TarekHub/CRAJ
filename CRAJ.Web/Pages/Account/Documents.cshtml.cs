using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CRAJ.Web.Data;
using CRAJ.Web.Helpers;
using CRAJ.Web.Models;
using CRAJ.Web.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace CRAJ.Web.Pages.Account
{
    [Authorize]
    public class DocumentsModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _hostEnvironment;


        private readonly UserManager<ApplicationUser> _userManager;

        public ApplicationUser User1 { get; set; }
        public IEnumerable<Document> Documents { get; set; }
        
        [BindProperty]
        public List<DocumentViewModel> DocumentImagesUploaded { get; set; }

        public DocumentsModel(ApplicationDbContext context, UserManager<ApplicationUser> userManager,
            IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _hostEnvironment = webHostEnvironment;
            _userManager = userManager;
        }

        public FileResult OnGetDownloadFileFromDatabase(string fileName)
        {
            var bytes = _context.Document.Where(d => "Document_"+d.TypeDocuement.Nom + "_" + d.Id.ToString() == fileName).SingleOrDefault()
                .DocumentImage;

            //Send the File to Download.
            return File(bytes, "application/octet-stream", fileName + ".png");
        }

        public async Task OnGetAsync()
        {
            Documents = new List<Document>();


            User1 = await _userManager.GetCurrentUser(HttpContext);

            // Referencing his custom properties
            await _context.Entry(User1).Reference(u=>u.ConseilJudiciaire).LoadAsync();
            await _context.Entry(User1).Reference(u => u.Tribunal).LoadAsync();

            if (User.IsInRole("Ministre de la Justice - وزير العدل"))
            {
                Documents = await _context.Document.Include(d=>d.Tribunal).ThenInclude(t=>t.ConseilJudiciaire)
                .Include(d=>d.Chambre).Include(d=>d.TypeDocuement).ToListAsync();

            }
            if (User.IsInRole("Procureur général - النائب العام") || User.IsInRole("Archiviste Régionale - الأرشيفي على مستوى المجلس"))
            {
                Documents = await _context.Document.Where(d=>d.Tribunal.ConseilJudiciaire.Name == User1.ConseilJudiciaire.Name && 
                d.isInConseilJ == true)
                .Include(d => d.Tribunal).ThenInclude(t => t.ConseilJudiciaire)
                .Include(d => d.Chambre).Include(d => d.TypeDocuement).ToListAsync();
            }
            if (User.IsInRole("Procureur de la République - وكيل الجمهورية") || User.IsInRole("Archiviste Tribunal - الأرشيفي على مستوى المحكمة"))
            {
                Documents = await _context.Document.Where(d => d.Tribunal.Name == User1.Tribunal.Name && d.isInTribunal==true)
                .Include(d => d.Tribunal).ThenInclude(t => t.ConseilJudiciaire)
                .Include(d => d.Chambre).Include(d => d.TypeDocuement).ToListAsync();
            }
            if (User.IsInRole("Titulaires de Droits - أصحاب الحقوق"))
            {
                Documents = await _context.Document.Where(d => d.IdPersonne.ToString() == User1.IdUser.ToString())
                .Include(d => d.Tribunal).ThenInclude(t => t.ConseilJudiciaire)
                .Include(d => d.Chambre).Include(d => d.TypeDocuement).ToListAsync();
            }

        }

    }
}
