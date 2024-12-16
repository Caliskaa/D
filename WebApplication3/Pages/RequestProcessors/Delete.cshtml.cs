using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Dem.Models;
using WebApplication3.Data;

namespace Dem.Pages.RequestProcessors
{
    public class DeleteModel : PageModel
    {
        private readonly WebApplication3.Data.WebApplication3Context _context;

        public DeleteModel(WebApplication3.Data.WebApplication3Context context)
        {
            _context = context;
        }

        [BindProperty]
      public RequestProcessor RequestProcessor { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.RequestProcessor == null)
            {
                return NotFound();
            }

            var requestprocessor = await _context.RequestProcessor.FirstOrDefaultAsync(m => m.ID == id);

            if (requestprocessor == null)
            {
                return NotFound();
            }
            else 
            {
                RequestProcessor = requestprocessor;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.RequestProcessor == null)
            {
                return NotFound();
            }
            var requestprocessor = await _context.RequestProcessor.FindAsync(id);

            if (requestprocessor != null)
            {
                RequestProcessor = requestprocessor;
                _context.RequestProcessor.Remove(RequestProcessor);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
