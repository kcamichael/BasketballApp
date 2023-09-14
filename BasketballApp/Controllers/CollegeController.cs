using BasketballApp.Service.CollegeServices;
using Microsoft.AspNetCore.Mvc;

namespace BasketballApp.Controllers
{
    public class CollegeController : Controller
    {
        private readonly ICollegeService _collegeService;

        public CollegeController(ICollegeService collegeService)
        {
            _collegeService = collegeService;
        }

        public async Task<IActionResult> Index()
        {
            var collegees = await _collegeService.GetCollege();
            return View(collegees);
        }

        public async Task<IActionResult> Detail(int id)
        {
            var college = await _collegeService.GetCollege(id);
            if (college is null) return NotFound();
            else
            {
                return View(college);
            }
        }

        public async Task<IActionResult> Create()
        {
            return View();
        }
    }
}
