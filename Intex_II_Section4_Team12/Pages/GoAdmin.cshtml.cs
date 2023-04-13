using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data;

namespace Intex_II_Section4_Team12.Pages
{
    [Authorize(Roles = "Admin")]
    public class GoAdminModel : PageModel
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly RoleManager<IdentityRole> roleManager;

        public GoAdminModel(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
        }

        [BindProperty]
        public string? Email { get; set; }

        [BindProperty]
        public string? Role { get; set; }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                var user = await userManager.FindByEmailAsync(Email);
                if (user == null)
                {
                    ModelState.AddModelError(string.Empty, "User not found.");
                    return Page();
                }

                // Check if the current user is trying to edit their own roles
                var currentUser = await userManager.GetUserAsync(User);
                if (currentUser.Email == user.Email)
                {
                    // Return an error or redirect to an error page, indicating that users cannot edit their own roles
                    ModelState.AddModelError(string.Empty, "Cannot edit own permissions.");
                    return Page();
                }

                // Get the current role of the user, if any
                var currentRole = await userManager.GetRolesAsync(user);
                if (currentRole.Count > 0)
                {
                    // Remove the user from the current role
                    var resultRemove = await userManager.RemoveFromRoleAsync(user, currentRole[0]);
                    if (!resultRemove.Succeeded)
                    {
                        foreach (var error in resultRemove.Errors)
                        {
                            ModelState.AddModelError(string.Empty, error.Description);
                        }
                        return Page();
                    }
                }

                // Check if the new role exists
                if (await roleManager.RoleExistsAsync(Role))
                {
                    var result = await userManager.AddToRoleAsync(user, Role);
                    if (result.Succeeded)
                    {
                        return RedirectToPage("/ConfirmAdmin");
                    }
                    else
                    {
                        foreach (var error in result.Errors)
                        {
                            ModelState.AddModelError(string.Empty, error.Description);
                        }
                        return Page();
                    }
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Role not found.");
                    return Page();
                }
            }

            return Page();
        }


        public void OnGet()
        {
        }
    }
}
