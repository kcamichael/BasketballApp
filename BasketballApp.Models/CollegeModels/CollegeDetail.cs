using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasketballApp.Models.CollegeModels
{
    public class CollegeDetail
    {
        [Key]
        [Required]
        public int ID { get; set; }
        [Required]
        [MaxLength(100)]
        public string Name { get; set; } = string.Empty;
        [Required]
        [MaxLength(100)]
        public string Conference { get; set; } = string.Empty;
        [MaxLength(100)]
        public string City { get; set; } = string.Empty;
        [MaxLength(50)]
        public string State { get; set; } = string.Empty;
        [MaxLength(200)]
        public string Arena { get; set; } = string.Empty;
    }
}
