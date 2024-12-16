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
    public class IndexModel : PageModel
    {
        private readonly WebApplication3.Data.WebApplication3Context _context;

        public IndexModel(WebApplication3.Data.WebApplication3Context context)
        {
            _context = context;
        }

        public IList<RequestProcessor> RequestProcessor { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.RequestProcessor != null)
            {
                RequestProcessor = await _context.RequestProcessor.ToListAsync();
            }
        }
    }
}
