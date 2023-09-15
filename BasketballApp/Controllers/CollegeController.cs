using BasketballApp.Models.CollegeModels;
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

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var colleges = await _collegeService.GetCollege();
            return View(colleges);
        }

        [HttpGet]
        public async Task<IActionResult> Detail(int id)
        {
            var college = await _collegeService.GetCollege(id);
            if (college is null) return NotFound();
            else
            {
                return View(college);
            }
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CollegeCreate model)
        {
            if (ModelState.IsValid)
            {
                var isSuccessful = await _collegeService.AddCollege(model);
                if (isSuccessful)
                {
                    return RedirectToAction(nameof(Index));
                }
            }
            return View(ModelState);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var college = await _collegeService.GetCollege(id);
            if (college is null) return NotFound();
            var collegeEdit = new CollegeEdit
            {
                ID = college.ID,
                Name = college.Name,
                Conference = college.Conference,
                City = college.City,
                State = college.State,
                Arena = college.Arena
            };
            return View(collegeEdit);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(CollegeEdit model)
        {
            if (ModelState.IsValid)
            {
                var isSuccessful = await _collegeService.UpdateCollege(model);
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
            var college = await _collegeService.GetCollege(ID);
            if (college is null) return NotFound();
            else
                return View(college);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")]
        public async Task<IActionResult> DeleteCollege(int ID)
        {
            var college = await _collegeService.GetCollege(ID);
            if (college is null) return NotFound();
            else
                await _collegeService.DeleteCollege(ID);
            return RedirectToAction(nameof(Index));
        }

    }
}
