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
    public class IndexModel : PageModel
    {
        private readonly RazorPages.WaterLogger.Data.WaterLoggerDbContext _context;

        public IndexModel(RazorPages.WaterLogger.Data.WaterLoggerDbContext context)
        {
            _context = context;
        }

        public IList<DrinkingWaterModel> DrinkingWaterModel { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.DrinkingSchedule != null)
            {
                DrinkingWaterModel = await _context.DrinkingSchedule.ToListAsync();
            }
        }
    }
}
