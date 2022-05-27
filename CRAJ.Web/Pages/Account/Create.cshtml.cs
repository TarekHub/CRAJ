using System;
using System.Collections.Generic;
using System.IO;
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
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CRAJ.Web.Pages.Account
{
    [Authorize]
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IWebHostEnvironment _hostenvironment;

        public ApplicationUser User1 { get; set; }
        public CreateModel(ApplicationDbContext context, UserManager<ApplicationUser> userManager,
            IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _userManager = userManager;
            _hostenvironment = webHostEnvironment;
        }
        public Document Document { get; set; }

        [BindProperty]
        public AddDocumentViewModel AddDocumentViewModel { get; set; }

        //public DocumentViewModel DocumentUpload { get; set; }

        public IEnumerable<TypeDoc> Types { get; set; }
        public async Task<IActionResult> OnGetAsync()
        {
            var user = await GetCurrentUser();
            Types = _context.TypeDoc;

            //Types = _context.TypeDoc.Select(a => new SelectListItem
            //{
            //    Value = a,
            //    Text = a.Nom

            //}).ToList();
            return Page();
        }
        public async Task<IActionResult> OnPost()
        {
            var user = await GetCurrentUser();

            if (ModelState.IsValid)
            {
                if (AddDocumentViewModel.FormDocument.Length > 0)
                {
                    using (var stream = new FileStream(Path.Combine(_hostenvironment.WebRootPath,
                        "uploadfiles", AddDocumentViewModel.FormDocument.FileName), FileMode.Create))
                    {
                        await AddDocumentViewModel.FormDocument.CopyToAsync(stream);
                    }
                }

                //save image to database.
                using (var memoryStream = new MemoryStream())
                {
                    await AddDocumentViewModel.FormDocument.CopyToAsync(memoryStream);

                    // Upload the file if less than 2 MB
                    if (memoryStream.Length < 2097152)
                    {
                        await _context.Document.AddAsync(new Document
                        {
                            IdPersonne = AddDocumentViewModel.IdPersonne,
                            DateCreation = DateTime.Now,
                            Tribunal = user.Tribunal,
                            Chambre = user.Chambre,
                            TypeDocuement = await _context.TypeDoc.FindAsync(AddDocumentViewModel.IdTypeDoc),
                            TypeArchive = AddDocumentViewModel.TypeArchive,
                            isInTribunal = true,
                            DocumentImage= memoryStream.ToArray()
                        });

                        await _context.SaveChangesAsync();

                        return RedirectToPage("Documents");
                    }
                }

            }
            return await this.OnGetAsync();
        }

        public async Task<ApplicationUser> GetCurrentUser()
        {
            User1 = await _userManager.GetCurrentUser(HttpContext);

            // Referencing his custom properties
            await _context.Entry(User1).Reference(u => u.ConseilJudiciaire).LoadAsync();
            await _context.Entry(User1).Reference(u => u.Tribunal).LoadAsync();
            await _context.Entry(User1).Reference(u => u.Chambre).LoadAsync();

            return User1;
        }
    }

}
