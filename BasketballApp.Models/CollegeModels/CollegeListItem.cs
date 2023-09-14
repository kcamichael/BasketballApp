using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasketballApp.Models.CollegeModels
{
    public class CollegeListItem
    {
        public int ID { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Conference { get; set; } = string.Empty;
    }
}
