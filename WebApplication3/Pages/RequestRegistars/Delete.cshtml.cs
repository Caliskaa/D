using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Dem.Models;
using WebApplication3.Data;

namespace Dem.Pages.RequestRegistars
{
    public class DeleteModel : PageModel
    {
        private readonly WebApplication3.Data.WebApplication3Context _context;

        public DeleteModel(WebApplication3.Data.WebApplication3Context context)
        {
            _context = context;
        }

        [BindProperty]
      public RequestRegistary RequestRegistary { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.RequestRegistary == null)
            {
                return NotFound();
            }

            var requestregistary = await _context.RequestRegistary.FirstOrDefaultAsync(m => m.ID == id);

            if (requestregistary == null)
            {
                return NotFound();
            }
            else 
            {
                RequestRegistary = requestregistary;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.RequestRegistary == null)
            {
                return NotFound();
            }
            var requestregistary = await _context.RequestRegistary.FindAsync(id);

            if (requestregistary != null)
            {
                RequestRegistary = requestregistary;
                _context.RequestRegistary.Remove(RequestRegistary);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
