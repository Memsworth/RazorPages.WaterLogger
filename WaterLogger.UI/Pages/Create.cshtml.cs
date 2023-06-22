using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using WaterLogger.DataAccess;
using WaterLogger.Domain.Abstraction.Services;
using WaterLogger.Domain.Models;
using WaterLogger.Domain.Models.DTO;
using WaterLogger.Service;

namespace WaterLogger.UI.Pages
{
    public class CreateModel : PageModel
    {
        private readonly IWaterService _waterService;
        public CreateModel(IWaterService waterService) => _waterService = waterService;

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public WaterPostDto Water { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || Water == null)
          {
              return Page();
          }
          await _waterService.AddWaterAsync(Water);
          return RedirectToPage("./Index");
        }
    }
}
