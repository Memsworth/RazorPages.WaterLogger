using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using WaterLogger.DataAccess;
using WaterLogger.Domain.Models;

namespace WaterLogger.UI.Pages
{
    public class CreateModel : PageModel
    {
        private readonly WaterLogger.DataAccess.WaterLoggerDbContext _context;

        public CreateModel(WaterLogger.DataAccess.WaterLoggerDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Water Water { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.WaterLog == null || Water == null)
            {
                return Page();
            }

            _context.WaterLog.Add(Water);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
