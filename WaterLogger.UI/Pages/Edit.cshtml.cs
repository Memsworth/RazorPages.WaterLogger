using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WaterLogger.DataAccess;
using WaterLogger.Domain.Models;

namespace WaterLogger.UI.Pages
{
    public class EditModel : PageModel
    {
        private readonly WaterLogger.DataAccess.WaterLoggerDbContext _context;

        public EditModel(WaterLogger.DataAccess.WaterLoggerDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Water Water { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.WaterLog == null)
            {
                return NotFound();
            }

            var water =  await _context.WaterLog.FirstOrDefaultAsync(m => m.Id == id);
            if (water == null)
            {
                return NotFound();
            }
            Water = water;
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

            _context.Attach(Water).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WaterExists(Water.Id))
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

        private bool WaterExists(int id)
        {
          return (_context.WaterLog?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
