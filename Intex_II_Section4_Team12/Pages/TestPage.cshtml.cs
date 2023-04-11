using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Intex_II_Section4_Team12.Pages
{
    [Authorize(Roles = "User")]
    public class TestPageModel : PageModel
    {
        public void OnGet()
        {
        }
    }
}
