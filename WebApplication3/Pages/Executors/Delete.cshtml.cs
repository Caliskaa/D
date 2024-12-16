using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Dem.Models;
using WebApplication3.Data;

namespace Dem.Pages.Executors
{
    public class DeleteModel : PageModel
    {
        private readonly WebApplication3.Data.WebApplication3Context _context;

        public DeleteModel(WebApplication3.Data.WebApplication3Context context)
        {
            _context = context;
        }

        [BindProperty]
      public Executor Executor { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Executor == null)
            {
                return NotFound();
            }

            var executor = await _context.Executor.FirstOrDefaultAsync(m => m.ID == id);

            if (executor == null)
            {
                return NotFound();
            }
            else 
            {
                Executor = executor;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Executor == null)
            {
                return NotFound();
            }
            var executor = await _context.Executor.FindAsync(id);

            if (executor != null)
            {
                Executor = executor;
                _context.Executor.Remove(Executor);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
