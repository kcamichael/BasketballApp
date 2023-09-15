using BasketballApp.Models.CollegeModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasketballApp.Models.CoachModels
{
    public class CoachDetail
    {
        public int ID { get; set; }
        public string Name { get; set; } = string.Empty;
        public CollegeListItem College { get; set; }
    }
}
