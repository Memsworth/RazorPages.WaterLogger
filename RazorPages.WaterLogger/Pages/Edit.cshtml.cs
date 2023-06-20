using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RazorPages.WaterLogger.Data;
using RazorPages.WaterLogger.Models;

namespace RazorPages.WaterLogger.Pages
{
    public class EditModel : PageModel
    {
        private readonly RazorPages.WaterLogger.Data.WaterLoggerDbContext _context;

        public EditModel(RazorPages.WaterLogger.Data.WaterLoggerDbContext context)
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

            var drinkingwatermodel =  await _context.DrinkingSchedule.FirstOrDefaultAsync(m => m.Id == id);
            if (drinkingwatermodel == null)
            {
                return NotFound();
            }
            DrinkingWaterModel = drinkingwatermodel;
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

            _context.Attach(DrinkingWaterModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DrinkingWaterModelExists(DrinkingWaterModel.Id))
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

        private bool DrinkingWaterModelExists(int id)
        {
          return (_context.DrinkingSchedule?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
