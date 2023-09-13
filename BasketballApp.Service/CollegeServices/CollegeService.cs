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
            var entity = _mapper.Map<CollegeEntity>(model);

            if (entity is not null)
            {
                await _context.College.AddAsync(entity);
                return await _context.SaveChangesAsync() > 0;
            }
            return false;
        }

        public async Task<bool> DeleteCollege(int id)
        {
            var collegeInDb = await _context.College.FindAsync(id);
            if (collegeInDb is null) return false;
            else
            {
                _context.College.Remove(collegeInDb);
                await _context.SaveChangesAsync();
                return true;
            }
        }

        public async Task<CollegeDetail> GetCollege(int id)
        {
            var collegeInDb = await _context.College
                .Include(p => p.Name)
                .Include(p => p.Conference)
                .Include(p => p.Arena)
                .Include(p => p.City)
                .Include(p => p.State)
                .SingleOrDefaultAsync(x => x.ID == id);
            if (collegeInDb is null) return null!;

            return _mapper.Map<CollegeDetail>(collegeInDb);
        }

        public async Task<List<CollegeListItem>> GetCollege()
        {
            return await _context.College.Select(p => _mapper.Map<CollegeListItem>(p)).ToListAsync();
        }

        public async Task<bool> UpdateCollege(CollegeEdit model)
        {
            var collegenInDb = await _context.College.AsNoTracking().FirstOrDefaultAsync(x => x.ID == model.ID);
            if (collegenInDb is null) return false;

            var conversion = _mapper.Map<CollegeEntity>(model);
            _context.College.Update(conversion);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
