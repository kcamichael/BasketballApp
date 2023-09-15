using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasketballApp.Models.PlayerModels
{
    public class PlayerCreate
    {
        [Key]
        public int ID { get; set; }
        public string Name { get; set; } = string.Empty;
        public int Number { get; set; }
        public string HighSchool { get; set; } = string.Empty;
        public int Height { get; set; }
        public int Weight { get; set; }
        public int CollegeId { get; set; }
        public int PositionId { get; set; }
    }
}
