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
    public class IndexModel : PageModel
    {
        private readonly WebApplication3.Data.WebApplication3Context _context;

        public IndexModel(WebApplication3.Data.WebApplication3Context context)
        {
            _context = context;
        }

        public IList<RequestExecute> RequestExecute { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.RequestExecute != null)
            {
                RequestExecute = await _context.RequestExecute.ToListAsync();
            }
        }
    }
}
