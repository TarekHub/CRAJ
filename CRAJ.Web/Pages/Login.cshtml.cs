using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CRAJ.Web.ViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CRAJ.Web.Pages
{
    public class LoginModel : PageModel
    {
        private readonly SignInManager<IdentityUser> _signInManager;

        [BindProperty]
        public Login Model { get; set; }
        public LoginModel(SignInManager<IdentityUser> signInManager)
        {
            _signInManager = signInManager;
        }
        public void OnGet()
        {
        }
        public async Task<IActionResult> OnPostAsync(string returnUrl=null)
        {
            if (ModelState.IsValid)
            {
                var identityResult = await _signInManager.PasswordSignInAsync(Model.Username, Model.Password, Model.RememberMe, false);
                if (identityResult.Succeeded)
                {
                    if(returnUrl is null || returnUrl =="/")
                    {
                        return RedirectToPage("Account/Documents");
                    }
                    else
                    {
                        RedirectToPage(returnUrl);
                    }
                }

                ModelState.AddModelError("", "Username or Password incorrect");
            }
            return Page();
        }
    }
}
