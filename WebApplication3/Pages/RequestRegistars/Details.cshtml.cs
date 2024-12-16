﻿using System;
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
    public class DetailsModel : PageModel
    {
        private readonly WebApplication3.Data.WebApplication3Context _context;

        public DetailsModel(WebApplication3.Data.WebApplication3Context context)
        {
            _context = context;
        }

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
    }
}
