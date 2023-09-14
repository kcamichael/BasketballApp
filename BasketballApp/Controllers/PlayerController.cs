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

        public async Task<IActionResult> Index()
        {
            var players = await _playerService.GetPlayers();
            return View(players);
        }

        public async Task<IActionResult> Detail(int id)
        {
            var player = await _playerService.GetPlayer(id);
            if (player is null) return NotFound();
            else
            {
                return View(player);
            }
        }

        public async Task<IActionResult> Create()
        {
            return View();
        }
    }
}
