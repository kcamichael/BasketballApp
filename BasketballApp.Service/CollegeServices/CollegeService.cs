using AutoMapper;
using BasketballApp.Data.BasketballDb;
using BasketballApp.Data.Entities;
using BasketballApp.Models.CollegeModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasketballApp.Service.CollegeServices
{
    public class CollegeService : ICollegeService
    {
        private readonly BasketballDbContext _context;
        private readonly IMapper _mapper;

        public CollegeService(BasketballDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<bool> AddCollege(CollegeCreate model)
        {
            var entity = new CollegeEntity
            {
                Name = model.Name,
                Conference = model.Conference,
                City = model.City,
                State = model.State,
                Arena = model.Arena
            };
            await _context.College.AddAsync(entity);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteCollege(int id)
        {
            var collegeInDb = await _context.College.FindAsync(id);
            if (collegeInDb is null) 
                return false;
            else
            {
                _context.College.Remove(collegeInDb);
                await _context.SaveChangesAsync();
                return true;
            }
        }

        public async Task<CollegeDetail> GetCollege(int id)
        {
            //var collegeInDb = await _context.College
            //    .Include(p => p.Name)
            //    .Include(p => p.Conference)
            //    .Include(p => p.Arena)
            //    .Include(p => p.City)
            //    .Include(p => p.State)
            //    .SingleOrDefaultAsync(x => x.ID == id);
            //if (collegeInDb is null) return null!;

            //return _mapper.Map<CollegeDetail>(collegeInDb);

            var collegeInDb = await _context.College.SingleOrDefaultAsync(x => x.ID == id);
            if (collegeInDb is null) return null!;

            return new CollegeDetail
            {
                ID = collegeInDb.ID,
                Name = collegeInDb.Name,
                Conference = collegeInDb.Conference,
                City = collegeInDb.City,
                State = collegeInDb.State,
                Arena = collegeInDb.Arena
            };
        }

        public async Task<List<CollegeListItem>> GetCollege()
        {
            return await _context.College.Select(c => new CollegeListItem
            {
                ID = c.ID,
                Name = c.Name,
                Conference = c.Conference,
            }).ToListAsync();
        }

        //public async Task<CollegeEdit> GetCollegeEdit(int id)
        //{
        //    var college = await _context.Players.
        //        SingleOrDefaultAsync(x => x.ID == id);
        //    if (college is null) return null!;
        //    return _mapper.Map<CollegeEdit>(college);
        //}

        public async Task<bool> UpdateCollege(CollegeEdit model)
        {
            var collegeInDb = await _context.College.FirstOrDefaultAsync(x => x.ID == model.ID);
            if (collegeInDb is null) return false;

            collegeInDb.Name = model.Name;
            collegeInDb.Conference = model.Conference;
            collegeInDb.City = model.City;
            collegeInDb.State = model.State;
            collegeInDb.Arena = model.Arena;
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
