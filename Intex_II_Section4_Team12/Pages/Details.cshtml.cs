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
using Intex_II_Section4_Team12.Repositories;
namespace Intex_II_Section4_Team12.Pages
{
    [Authorize(Roles = "Admin, Researcher")]
    public class DetailsModel : PageModel
    {
        private readonly Intex_II_Section4_Team12.Context.MummyContext _context;
        private IPhotoRepository _photoRepo;
        public string? BurialNumberId { get; set; }
        public ICollection<string?> PhotoNames { get; set; }
        public DetailsModel(Intex_II_Section4_Team12.Context.MummyContext context, IPhotoRepository temp)
        {
            _context = context;
            _photoRepo = temp;
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
                BurialNumberId = burialmain.Squarenorthsouth + burialmain.Northsouth + burialmain.Squareeastwest + burialmain.Eastwest + burialmain.Area + burialmain.Burialnumber;
                PhotoNames = _photoRepo.Photos(BurialNumberId);
                Burialmain = burialmain;
            }
            return Page();
        }
    }
}
//this is a comment
