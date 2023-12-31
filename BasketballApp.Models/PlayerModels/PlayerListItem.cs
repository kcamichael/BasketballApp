﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasketballApp.Models.PlayerModels
{
    public class PlayerListItem
    {
        [Key]
        public int ID { get; set; }
        public string Name { get; set; } = string.Empty;
        public int Number { get; set; }
        public string CollegeName { get; set; }
        public string PositionName { get; set; }
    }
}
