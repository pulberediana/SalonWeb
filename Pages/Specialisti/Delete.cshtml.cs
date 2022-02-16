using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SalonWeb.Data;
using SalonWeb.Models;

namespace SalonWeb.Pages.Specialisti
{
    public class DeleteModel : PageModel
    {
        private readonly SalonWeb.Data.SalonWebContext _context;

        public DeleteModel(SalonWeb.Data.SalonWebContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Specialist Specialist { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Specialist = await _context.Specialist.FirstOrDefaultAsync(m => m.ID == id);

            if (Specialist == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Specialist = await _context.Specialist.FindAsync(id);

            if (Specialist != null)
            {
                _context.Specialist.Remove(Specialist);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
