﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Dem.Models;
using WebApplication3.Data;

namespace Dem.Pages.RequestExecuts
{
    public class EditModel : PageModel
    {
        private readonly WebApplication3.Data.WebApplication3Context _context;

        public EditModel(WebApplication3.Data.WebApplication3Context context)
        {
            _context = context;
        }

        [BindProperty]
        public RequestExecute RequestExecute { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.RequestExecute == null)
            {
                return NotFound();
            }

            var requestexecute =  await _context.RequestExecute.FirstOrDefaultAsync(m => m.ID == id);
            if (requestexecute == null)
            {
                return NotFound();
            }
            RequestExecute = requestexecute;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(RequestExecute).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RequestExecuteExists(RequestExecute.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool RequestExecuteExists(int id)
        {
          return (_context.RequestExecute?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}