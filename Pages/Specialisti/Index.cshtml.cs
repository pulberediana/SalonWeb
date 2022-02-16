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
    public class IndexModel : PageModel
    {
        private readonly SalonWeb.Data.SalonWebContext _context;

        public IndexModel(SalonWeb.Data.SalonWebContext context)
        {
            _context = context;
        }

        public IList<Specialist> Specialist { get;set; }

        public async Task OnGetAsync()
        {
            Specialist = await _context.Specialist.ToListAsync();
        }
    }
}
