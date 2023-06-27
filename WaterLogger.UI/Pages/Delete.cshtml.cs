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
            var waterItem = await _waterService.GetWaterByIdAsync(id);
            if (waterItem.Status is not ResponseStatus.Success)
            {
                return NotFound($"{waterItem.Message}");
            }

            WaterItemToDelete = waterItem.Data;
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var result = await _waterService.DeleteWaterAsync(WaterItemToDelete);
            return RedirectToPage(result.Status is not ResponseStatus.Success ? "./Error" : "./Index");
        }
    }
}
