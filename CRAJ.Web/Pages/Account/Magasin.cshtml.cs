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
    public class MagasinModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public MagasinModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Magasin> Magasins{ get; set; }



        public async Task OnGetAsync()
        {
            Magasins = await _context.Magasin.Include(m => m.ConseilJudiciaire).ToListAsync();

        }
    }
}
