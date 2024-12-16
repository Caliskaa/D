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
    public class IndexModel : PageModel
    {
        private readonly WebApplication3.Data.WebApplication3Context _context;

        public IndexModel(WebApplication3.Data.WebApplication3Context context)
        {
            _context = context;
        }

        public IList<RequestRemont> RequestRemont { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.RequestRemont != null)
            {
                RequestRemont = await _context.RequestRemont.ToListAsync();
            }
        }
    }
}
