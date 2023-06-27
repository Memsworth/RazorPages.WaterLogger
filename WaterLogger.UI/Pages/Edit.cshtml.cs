using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WaterLogger.DataAccess;
using WaterLogger.Domain.Abstraction.Services;
using WaterLogger.Domain.Models;

namespace WaterLogger.UI.Pages
{
    public class EditModel : PageModel
    {
        private readonly IWaterService _waterService;

        public EditModel(IWaterService waterService) => _waterService = waterService;

        [BindProperty]
        public Water Water { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int id)
        {

            var waterItem = await _waterService.GetWaterByIdAsync(id);
            if (waterItem.Status is not ResponseStatus.Success)
            {
                return NotFound($"{waterItem.Message}");
            }
            Water = waterItem.Data;
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

            var result = await _waterService.UpdateWaterAsync(Water);

            return RedirectToPage(result.Status is not ResponseStatus.Success ? "./Error" : "./Index");
        }
    }
}
