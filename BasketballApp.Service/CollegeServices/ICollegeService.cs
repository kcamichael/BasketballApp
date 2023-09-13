using BasketballApp.Models.CollegeModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasketballApp.Service.CollegeServices
{
    public interface ICollegeService
    {
        public Task<bool> AddCollege(CollegeCreate model);
        public Task<bool> UpdateCollege(CollegeEdit model);
        public Task<bool> DeleteCollege(int id);
        public Task<CollegeDetail> GetCollege(int id);
        public Task<List<CollegeListItem>> GetCollege();

    }
}
