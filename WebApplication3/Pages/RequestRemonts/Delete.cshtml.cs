using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebApplication3.Data;
using WebApplication3.Models;

namespace WebApplication3.Pages.RequestRemonts
{
    public class DeleteModel : PageModel
    {
        private readonly WebApplication3.Data.WebApplication3Context _context;

        public DeleteModel(WebApplication3.Data.WebApplication3Context context)
        {
            _context = context;
        }

        [BindProperty]
      public RequestRemont RequestRemont { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.RequestRemont == null)
            {
                return NotFound();
            }

            var requestremont = await _context.RequestRemont.FirstOrDefaultAsync(m => m.ID == id);

            if (requestremont == null)
            {
                return NotFound();
            }
            else 
            {
                RequestRemont = requestremont;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.RequestRemont == null)
            {
                return NotFound();
            }
            var requestremont = await _context.RequestRemont.FindAsync(id);

            if (requestremont != null)
            {
                RequestRemont = requestremont;
                _context.RequestRemont.Remove(RequestRemont);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
