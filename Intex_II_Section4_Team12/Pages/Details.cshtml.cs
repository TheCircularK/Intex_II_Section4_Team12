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
    public class DetailsModel : PageModel
    {
        private readonly Intex_II_Section4_Team12.Context.MummyContext _context;

        public DetailsModel(Intex_II_Section4_Team12.Context.MummyContext context)
        {
            _context = context;
        }

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
    }
}
//this is a comment