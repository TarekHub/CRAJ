    using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CRAJ.Web.Data;
using CRAJ.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CRAJ.Web.Pages.Account
{
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        public CreateModel(ApplicationDbContext context)
        {
            _context = context;
        }
        [BindProperty]
        public Document Document { get; set; }

        public List<SelectListItem> Types { get; set; }
        public IActionResult OnGet()
        {
            Types = _context.TypeDoc.Select(a => new SelectListItem
            {
                Value = a.Nom,
                Text = a.Nom
            }).ToList();
            return Page();
        }
        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                await _context.Document.AddAsync(Document);
                await _context.SaveChangesAsync();

                return RedirectToPage("Documents");
            }
            return this.OnGet();
        }
    }
}
