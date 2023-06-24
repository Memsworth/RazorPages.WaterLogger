using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WaterLogger.DataAccess;
using WaterLogger.Domain.Abstraction.Services;
using WaterLogger.Domain.Models;

namespace WaterLogger.UI.Pages
{
    public class DeleteModel : PageModel
    {
        private readonly IWaterService _waterService;
        public DeleteModel(IWaterService waterService)
        {
            _waterService = waterService;
        }

        [BindProperty]
        public Water WaterItemToDelete { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var waterItem = await _waterService.GetWaterByIdAsync(id);

            
            if (waterItem is null)
            {
                return NotFound();
            }

            WaterItemToDelete = waterItem;
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (WaterItemToDelete is null)
            {
                return RedirectToPage("./Error");
            }
            if (WaterItemToDelete is not null)
            {
                await _waterService.DeleteWaterAsync(WaterItemToDelete);
            }
            return RedirectToPage("./Index");
        }
    }
}
