using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WaterLogger.DataAccess;
using WaterLogger.Domain.Abstraction.Services;
using WaterLogger.Domain.Abstraction.UnitOfWork;
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
            if (await _waterService.GetAllExerciseAsync() != null)
            {
                Water = await _waterService.GetAllExerciseAsync();
            }
        }
    }
}
