using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WaterLogger.Domain.Abstraction.Services;
using WaterLogger.Domain.Models;

namespace WaterLogger.UI.Pages
{
    public class IndexModel : PageModel
    {
        private readonly IWaterService _waterService;

        public IndexModel(IWaterService waterService) => _waterService = waterService;

        public IList<Water> Water { get;set; } = default!;

        public async Task OnGetAsync()
        {
            var item = await _waterService.GetAllWaterAsync();
            if (item.Status is ResponseStatus.Success)
            {
                Water = item.Data.ToList();
            }
        }
    }
}
