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

namespace Intex_II_Section4_Team12.Pages
{
    [Authorize(Roles = "Admin, Researcher")]
    public class DatabaseAdminModel : PageModel
    {
        private readonly Intex_II_Section4_Team12.Context.MummyContext _context;

        public DatabaseAdminModel(Intex_II_Section4_Team12.Context.MummyContext context)
        {
            _context = context;
        }

        public IList<Burialmain> Burialmain { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Burialmains != null)
            {
                Burialmain = await _context.Burialmains.ToListAsync();
            }
        }
    }
}
