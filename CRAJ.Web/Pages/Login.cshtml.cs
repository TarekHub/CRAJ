using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using CRAJ.Web.Data;
using CRAJ.Web.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CRAJ.Web.Pages
{
    public class LoginModel : PageModel
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;

        [BindProperty]
        public Login Model { get; set; }
        public LoginModel(SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }
        public void OnGet()
        {
        }
        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            if (ModelState.IsValid)
            {
                var identityResult = await _signInManager.PasswordSignInAsync(Model.Username, Model.Password, Model.RememberMe, false);

                if (identityResult.Succeeded)
                {
                    var user = await _userManager.FindByEmailAsync(Model.Username);
                    var role = await _userManager.GetRolesAsync(user);

                    if (returnUrl is null || returnUrl == "/")
                    {
                        if (role.First()=="Archiviste du Centre - الأرشيفي على مستوى مركز الأرشيف" ||
                            role.First() == "Directeur du Centre - مدير المركز")
                        {
                            return RedirectToPage("Account/Magasin");
                        }
                        if (role.First() == "Avocat - محامي")
                        {
                            return RedirectToPage("Avocat/Search");

                        }
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
