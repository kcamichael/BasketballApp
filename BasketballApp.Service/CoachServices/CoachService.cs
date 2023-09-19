using AutoMapper;
using BasketballApp.Data.BasketballDb;
using BasketballApp.Data.Entities;
using BasketballApp.Models.CoachModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasketballApp.Service.CoachServices
{
    public class CoachService : ICoachService
    {
        private readonly BasketballDbContext _context;
        private readonly IMapper _mapper;

        public CoachService(BasketballDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<bool> AddCoach(CoachCreate model)
        {
            var entity = new CoachEntity
            {
                Name = model.Name,
                CollegeId = model.CollegeId,    
            };
            await _context.Coach.AddAsync(entity);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteCoach(int id)
        {
            var coachInDb = await _context.Coach.FindAsync(id);
            if (coachInDb is null) return false;
            else
            {
                _context.Coach.Remove(coachInDb);
                await _context.SaveChangesAsync();
                return true;
            }
        }

        public async Task<CoachDetail> GetCoach(int id)
        {
            var coachInDb = await _context.Coach.Include(p => p.College).SingleOrDefaultAsync(x => x.ID == id);
            if (coachInDb is null) return null!;

            return new CoachDetail
            {
                ID = coachInDb.ID,
                Name = coachInDb.Name,
                College = new Models.CollegeModels.CollegeListItem()
                {
                    ID = coachInDb.CollegeId,
                    Name = coachInDb.College.Name
                }
            };
        }

        public async Task<List<CoachListItem>> GetCoach()
        {
            return await _context.Coach.Include(c => c.College).Select(c => new CoachListItem
            {
                ID = c.ID,
                Name = c.Name,
                CollegeName = c.College.Name
            }).ToListAsync();
        }

        public async Task<List<CoachListItem>> GetCoachByCollege(string CollegeName)
        {
            return await _context.Coach.Include(p => p.College).Where(p => p.College.Name == CollegeName).Select(p => new CoachListItem
            {
                ID = p.ID,
                Name = p.Name,
            }).ToListAsync();
        }

        //public async Task<CoachEdit> GetCoachEdit(int id)
        //{
        //    var coach = await _context.Players.Include(p => p.College).
        //        SingleOrDefaultAsync(x => x.ID == id);
        //    if (coach is null) return null!;
        //        return _mapper.Map<CoachEdit>(coach);
        //}
        public async Task<bool> UpdateCoach(CoachEdit model)
        {
            var coachInDb = await _context.Coach.FirstOrDefaultAsync(x => x.ID == model.ID);
            if (coachInDb is null) return false;

            coachInDb.Name = model.Name;
            coachInDb.CollegeId = model.CollegeId;
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
