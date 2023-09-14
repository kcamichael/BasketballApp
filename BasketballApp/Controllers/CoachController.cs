using BasketballApp.Service.CoachServices;
using Microsoft.AspNetCore.Mvc;

namespace BasketballApp.Controllers
{
    public class CoachController : Controller
    {
        private readonly ICoachService _coachService;

        public CoachController(ICoachService coachService)
        {
            _coachService = coachService;
        }

        public async Task<IActionResult> Index()
        {
            var coaches = await _coachService.GetCoach();
            return View(coaches);
        }

        public async Task<IActionResult> Detail(int id)
        {
            var coach = await _coachService.GetCoach(id);
            if (coach is null) return NotFound();
            else
            {
                return View(coach);
            }
        }

        public async Task<IActionResult> Create()
        {
            return View();
        }
    }
}
