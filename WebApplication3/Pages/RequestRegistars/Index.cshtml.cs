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
    public class IndexModel : PageModel
    {
        private readonly WebApplication3.Data.WebApplication3Context _context;

        public IndexModel(WebApplication3.Data.WebApplication3Context context)
        {
            _context = context;
        }

        public IList<RequestRegistary> RequestRegistary { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.RequestRegistary != null)
            {
                RequestRegistary = await _context.RequestRegistary.ToListAsync();
            }
        }
    }
}
