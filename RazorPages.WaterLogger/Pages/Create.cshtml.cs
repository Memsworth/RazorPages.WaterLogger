using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using RazorPages.WaterLogger.Data;
using RazorPages.WaterLogger.Models;

namespace RazorPages.WaterLogger.Pages
{
    public class CreateModel : PageModel
    {
        private readonly RazorPages.WaterLogger.Data.WaterLoggerDbContext _context;

        public CreateModel(RazorPages.WaterLogger.Data.WaterLoggerDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public DrinkingWaterModel DrinkingWaterModel { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.DrinkingSchedule == null || DrinkingWaterModel == null)
            {
                return Page();
            }

            _context.DrinkingSchedule.Add(DrinkingWaterModel);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
