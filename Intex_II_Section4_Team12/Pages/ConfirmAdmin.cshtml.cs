using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data;

namespace Intex_II_Section4_Team12.Pages
{
    [Authorize(Roles = "Admin")]
    public class ConfirmAdminModel : PageModel
    {
        public void OnGet()
        {
        }
    }
}
