using BasketballApp.Models.PlayerModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasketballApp.Service.PlayerServices
{
    public interface IPlayerService
    {
        public Task<bool> AddPlayer(PlayerCreate model);
        public Task<bool> UpdatePlayer(PlayerEdit model);
        public Task<bool> DeletePlayer(int id);
        public Task<PlayerDetail> GetPlayer(int id);
        public Task<List<PlayerListItem>> GetPlayers();
        public Task<List<PlayerListItem>> GetPlayersByCollege(string CollegeName);
        public Task<List<PlayerListItem>> GetPlayersByPosition(string PositionName);

    }
}
