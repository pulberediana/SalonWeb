using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SalonWeb.Data;
using SalonWeb.Models;

namespace SalonWeb.Pages.Specialisti
{
    public class EditModel : PageModel
    {
        private readonly SalonWeb.Data.SalonWebContext _context;

        public EditModel(SalonWeb.Data.SalonWebContext context)
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

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Specialist).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SpecialistExists(Specialist.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool SpecialistExists(int id)
        {
            return _context.Specialist.Any(e => e.ID == id);
        }
    }
}
