using AutoMapper;
using BasketballApp.Data.BasketballDb;
using BasketballApp.Data.Entities;
using BasketballApp.Models.PlayerModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasketballApp.Service.PlayerServices
{
    public class PlayerService : IPlayerService
    {
        private readonly BasketballDbContext _context;
        private readonly IMapper _mapper;

        public PlayerService(BasketballDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<bool> AddPlayer(PlayerCreate model)
        {
            var entity = _mapper.Map<PlayerEntity>(model);

            if (entity is not null)
            {
                await _context.Players.AddAsync(entity);
                return await _context.SaveChangesAsync() > 0;
            }
            return false;
        }

        public async Task<bool> DeletePlayer(int id)
        {
            var hooper = await _context.Players.FindAsync(id);
            if (hooper is null) return false;
            else
            {
                _context.Players.Remove(hooper);
                await _context.SaveChangesAsync();
                return true;
            }
        }
        public async Task<PlayerDetail> GetPlayer(int id)
        {
            var hooper = await _context.Players.Include(p => p.College).Include(p => p.Position).
                SingleOrDefaultAsync(x => x.ID == id);
            if (hooper is null) return null!;

            return _mapper.Map<PlayerDetail>(hooper);
        }

        public async Task<List<PlayerListItem>> GetPlayers()
        {
            return await _context.Players.Include(c => c.College).Select(c => new PlayerListItem
            {
                ID = c.ID,
                Name = c.Name,
                CollegeName = c.College.Name
            }).ToListAsync();
        }

        public async Task<List<PlayerListItem>> GetPlayersByCollege(string CollegeName)
        {
            return await _context.Players.Include(c => c.College).Where(c => c.College.Name == CollegeName).Select(c => new PlayerListItem
            {
                ID = c.ID,
                Name = c.Name
            }).ToListAsync();
        }

        public async Task<List<PlayerListItem>> GetPlayersByPosition(string PositionName)
        {
            return await _context.Players.Include(p => p.Position).Where(p => p.Position.Name == PositionName).Select(p => new PlayerListItem
            {
                ID = p.ID,
                Name = p.Name,
            }).ToListAsync();
        }

        public async Task<bool> UpdatePlayer(PlayerEdit model)
        {
            var hooper = await _context.Players.AsNoTracking().FirstOrDefaultAsync(x => x.ID == model.ID);
            if (hooper is null) return false;

            var conversion = _mapper.Map<PlayerEntity>(model);
            _context.Players.Update(conversion);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
