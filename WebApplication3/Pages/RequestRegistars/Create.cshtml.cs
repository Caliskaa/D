using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Dem.Models;
using WebApplication3.Data;

namespace Dem.Pages.RequestRegistars
{
    public class CreateModel : PageModel
    {
        private readonly WebApplication3.Data.WebApplication3Context _context;

        public CreateModel(WebApplication3.Data.WebApplication3Context context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public RequestRegistary RequestRegistary { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.RequestRegistary == null || RequestRegistary == null)
            {
                return Page();
            }

            _context.RequestRegistary.Add(RequestRegistary);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
