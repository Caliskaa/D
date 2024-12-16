using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Dem.Models;
using WebApplication3.Data;

namespace Dem.Pages.Reports
{
    public class DetailsModel : PageModel
    {
        private readonly WebApplication3.Data.WebApplication3Context _context;

        public DetailsModel(WebApplication3.Data.WebApplication3Context context)
        {
            _context = context;
        }

      public Report Report { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Report == null)
            {
                return NotFound();
            }

            var report = await _context.Report.FirstOrDefaultAsync(m => m.ID == id);
            if (report == null)
            {
                return NotFound();
            }
            else 
            {
                Report = report;
            }
            return Page();
        }
    }
}
