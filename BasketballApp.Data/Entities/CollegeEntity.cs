using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasketballApp.Data.Entities
{
    public class CollegeEntity
    {
        [Key]
        [Required]
        public int ID { get; set; }
        [Required]
        [MaxLength(200)]
        public string Name { get; set; } = string.Empty;
        [Required]
        [MaxLength(150)]
        public string Conference { get; set; } = string.Empty;
        [MaxLength(100)]
        public string City { get; set; } = string.Empty;
        [MaxLength(50)]
        public string State { get; set; } = string.Empty;
        [MaxLength(250)]
        public string Arena { get; set; } = string.Empty;

    }
}
