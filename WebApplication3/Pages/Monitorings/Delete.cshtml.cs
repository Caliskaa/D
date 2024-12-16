using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Dem.Models;
using WebApplication3.Data;

namespace Dem.Pages.Monitorings
{
    public class DeleteModel : PageModel
    {
        private readonly WebApplication3.Data.WebApplication3Context _context;

        public DeleteModel(WebApplication3.Data.WebApplication3Context context)
        {
            _context = context;
        }

        [BindProperty]
      public Monitoring Monitoring { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Monitoring == null)
            {
                return NotFound();
            }

            var monitoring = await _context.Monitoring.FirstOrDefaultAsync(m => m.ID == id);

            if (monitoring == null)
            {
                return NotFound();
            }
            else 
            {
                Monitoring = monitoring;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Monitoring == null)
            {
                return NotFound();
            }
            var monitoring = await _context.Monitoring.FindAsync(id);

            if (monitoring != null)
            {
                Monitoring = monitoring;
                _context.Monitoring.Remove(Monitoring);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
