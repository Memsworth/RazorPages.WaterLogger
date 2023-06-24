using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WaterLogger.Domain.Abstraction.Services;
using WaterLogger.Domain.Models;
using WaterLogger.Domain.Models.DTO;

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
        public WaterPostDto WaterPostDto { get; set; } = default!;

        public async Task<IActionResult> OnPostAsync()
        { 
            if (!ModelState.IsValid || WaterPostDto is null) return RedirectToPage("/Error");
            var response = await _waterService.AddWaterAsync(WaterPostDto);
            return RedirectToPage(response.Status is ResponseStatus.Success ? "./Index" : "/Error");
        }
    }
}
