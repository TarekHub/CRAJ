    using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CRAJ.Web.Data;
using CRAJ.Web.Helpers;
using CRAJ.Web.Models;
using Microsoft.AspNetCore.Authorization;
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

        public ApplicationUser User1 { get; set; }
        public CreateModel(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        [BindProperty]
        public Document Document { get; set; }

        public List<SelectListItem> Types { get; set; }
        public async Task<IActionResult> OnGetAsync()
        {
            User1 = await _userManager.GetCurrentUser(HttpContext);

            // Referencing his custom properties
            await _context.Entry(User1).Reference(u => u.ConseilJudiciaire).LoadAsync();
            await _context.Entry(User1).Reference(u => u.Tribunal).LoadAsync();
            await _context.Entry(User1).Reference(u => u.Chambre).LoadAsync();

            Types = _context.TypeDoc.Select(a => new SelectListItem
            {
                Value = a.Id.ToString(),
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
            return await this.OnGetAsync();
        }
    }
}
