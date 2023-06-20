using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorPages.WaterLogger.Data;
using RazorPages.WaterLogger.Models;

namespace RazorPages.WaterLogger.Pages
{
    public class DeleteModel : PageModel
    {
        private readonly RazorPages.WaterLogger.Data.WaterLoggerDbContext _context;

        public DeleteModel(RazorPages.WaterLogger.Data.WaterLoggerDbContext context)
        {
            _context = context;
        }

        [BindProperty]
      public DrinkingWaterModel DrinkingWaterModel { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.DrinkingSchedule == null)
            {
                return NotFound();
            }

            var drinkingwatermodel = await _context.DrinkingSchedule.FirstOrDefaultAsync(m => m.Id == id);

            if (drinkingwatermodel == null)
            {
                return NotFound();
            }
            else 
            {
                DrinkingWaterModel = drinkingwatermodel;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.DrinkingSchedule == null)
            {
                return NotFound();
            }
            var drinkingwatermodel = await _context.DrinkingSchedule.FindAsync(id);

            if (drinkingwatermodel != null)
            {
                DrinkingWaterModel = drinkingwatermodel;
                _context.DrinkingSchedule.Remove(DrinkingWaterModel);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
