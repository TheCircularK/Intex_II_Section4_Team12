using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Intex_II_Section4_Team12.Context;
using Intex_II_Section4_Team12.Models;
using Microsoft.AspNetCore.Authorization;
using System.Data;

namespace Intex_II_Section4_Team12.Pages
{
    [Authorize(Roles = "Admin, Researcher")]
    public class CreateModel : PageModel
    {
        private readonly Intex_II_Section4_Team12.Context.MummyContext _context;

        public CreateModel(Intex_II_Section4_Team12.Context.MummyContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Burialmain Burialmain { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Burialmains == null || Burialmain == null)
            {
                return Page();
            }

            _context.Burialmains.Add(Burialmain);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
