using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Dem.Models;
using WebApplication3.Data;

namespace Dem.Pages.RequestExecuts
{
    public class DetailsModel : PageModel
    {
        private readonly WebApplication3.Data.WebApplication3Context _context;

        public DetailsModel(WebApplication3.Data.WebApplication3Context context)
        {
            _context = context;
        }

      public RequestExecute RequestExecute { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.RequestExecute == null)
            {
                return NotFound();
            }

            var requestexecute = await _context.RequestExecute.FirstOrDefaultAsync(m => m.ID == id);
            if (requestexecute == null)
            {
                return NotFound();
            }
            else 
            {
                RequestExecute = requestexecute;
            }
            return Page();
        }
    }
}
