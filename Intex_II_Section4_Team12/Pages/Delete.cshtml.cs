using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Intex_II_Section4_Team12.Context;
using Intex_II_Section4_Team12.Models;
using Microsoft.AspNetCore.Authorization;
using System.Data;

namespace Intex_II_Section4_Team12.Pages
{
    [Authorize(Roles = "Admin, Researcher")]
    public class DeleteModel : PageModel
    {
        private readonly Intex_II_Section4_Team12.Context.MummyContext _context;

        public DeleteModel(Intex_II_Section4_Team12.Context.MummyContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Burialmain Burialmain { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(long? id)
        {
            if (id == null || _context.Burialmains == null)
            {
                return NotFound();
            }

            var burialmain = await _context.Burialmains.FirstOrDefaultAsync(m => m.Id == id);

            if (burialmain == null)
            {
                return NotFound();
            }
            else 
            {
                Burialmain = burialmain;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(long? id)
        {
            if (id == null || _context.Burialmains == null)
            {
                return NotFound();
            }
            var burialmain = await _context.Burialmains.FindAsync(id);

            if (burialmain != null)
            {
                Burialmain = burialmain;
                _context.Burialmains.Remove(Burialmain);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./DatabaseAdmin");
        }
    }
}
