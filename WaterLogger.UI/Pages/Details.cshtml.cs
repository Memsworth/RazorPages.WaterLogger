using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WaterLogger.DataAccess;
using WaterLogger.Domain.Models;

namespace WaterLogger.UI.Pages
{
    public class DetailsModel : PageModel
    {
        private readonly WaterLogger.DataAccess.WaterLoggerDbContext _context;

        public DetailsModel(WaterLogger.DataAccess.WaterLoggerDbContext context)
        {
            _context = context;
        }

      public Water Water { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.WaterLog == null)
            {
                return NotFound();
            }

            var water = await _context.WaterLog.FirstOrDefaultAsync(m => m.Id == id);
            if (water == null)
            {
                return NotFound();
            }
            else 
            {
                Water = water;
            }
            return Page();
        }
    }
}
