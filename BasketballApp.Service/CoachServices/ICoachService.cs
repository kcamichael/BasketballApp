using BasketballApp.Models.CoachModels;
using BasketballApp.Models.PlayerModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasketballApp.Service.CoachServices
{
    public interface ICoachService
    {
        public Task<bool> AddCoach(CoachCreate model);
        public Task<bool> UpdateCoach(CoachEdit model);
        public Task<bool> DeleteCoach(int id);
        public Task<CoachDetail> GetCoach(int id);
        public Task<List<CoachListItem>> GetCoach();
        public Task<List<CoachListItem>> GetCoachByCollege(string CollegeName);
        //public Task<CoachEdit> GetCoachEdit(int id);
    }
}
