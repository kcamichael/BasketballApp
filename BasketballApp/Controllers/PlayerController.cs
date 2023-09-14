using BasketballApp.Models.PlayerModels;
using BasketballApp.Service.PlayerServices;
using Microsoft.AspNetCore.Mvc;

namespace BasketballApp.Controllers
{
    public class PlayerController : Controller
    {
        private readonly IPlayerService _playerService;

        public PlayerController(IPlayerService playerService)
        {
            _playerService = playerService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var players = await _playerService.GetPlayers();
            return View(players);
        }

        [HttpGet]
        public async Task<IActionResult> Detail(int id)
        {
            var player = await _playerService.GetPlayer(id);
            if (player is null) return NotFound();
            else
            {
                return View(player);
            }
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(PlayerCreate model)
        {
            if (ModelState.IsValid)
            {
                var isSuccessful = await _playerService.AddPlayer(model);
                if(isSuccessful)
                {
                    return RedirectToAction(nameof(Index));
                }
            }
            return View(ModelState);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var player = await _playerService.GetPlayer(id);
            if (player is null) return NotFound();
            else
            {
                return View(player);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(PlayerEdit model)
        {
            if (ModelState.IsValid)
            {
                var isSuccessful = await _playerService.UpdatePlayer(model);
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
            var player = await _playerService.GetPlayer(ID);
            if (player is null) return NotFound();
            else
                return View(player);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")]
        public async Task<IActionResult> DeletePlayer(int ID)
        {
            var player = await _playerService.GetPlayer(ID);
            if (player is null) return NotFound();
            else
                await _playerService.DeletePlayer(ID);
            return RedirectToAction(nameof(Index));
        }


    }
}
