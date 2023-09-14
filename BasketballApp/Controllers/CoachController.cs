using BasketballApp.Models.CoachModels;
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

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var coachs = await _coachService.GetCoach();
            return View(coachs);
        }

        [HttpGet]
        public async Task<IActionResult> Detail(int id)
        {
            var coach = await _coachService.GetCoach(id);
            if (coach is null) return NotFound();
            else
            {
                return View(coach);
            }
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CoachCreate model)
        {
            if (ModelState.IsValid)
            {
                var isSuccessful = await _coachService.AddCoach(model);
                if (isSuccessful)
                {
                    return RedirectToAction(nameof(Index));
                }
            }
            return View(ModelState);
        }

        [ValidateAntiForgeryToken]
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var coach = await _coachService.GetCoach(id);
            if (coach is null) return NotFound();
            else
                return View(coach);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(CoachEdit model)
        {
            if (ModelState.IsValid)
            {
                var isSuccessful = await _coachService.UpdateCoach(model);
                if (isSuccessful)
                {
                    return RedirectToAction(nameof(Index));
                }
            }
            return View(ModelState);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int/*?*/ ID)
        {
            var coach = await _coachService.GetCoach(ID);
            if (coach is null) return NotFound();
            else
                return View(coach);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")]
        public async Task<IActionResult> DeleteCoach(int ID)
        {
            var coach = await _coachService.GetCoach(ID);
            if (coach is null) return NotFound();
            else
                await _coachService.DeleteCoach(ID);
            return RedirectToAction(nameof(Index));
        }


    }
}
