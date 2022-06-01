using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CRAJ.Web.Data;
using CRAJ.Web.Helpers;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CRAJ.Web.Pages.Account
{
    public class ProfilModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public ApplicationUser User1 { get; set; }

        public ProfilModel(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task OnGetAsync()
        {
            User1 = await _userManager.GetCurrentUser(HttpContext);

            // Referencing his custom properties
            await _context.Entry(User1).Reference(u => u.ConseilJudiciaire).LoadAsync();
            await _context.Entry(User1).Reference(u => u.Tribunal).LoadAsync();
        }
    }
}
