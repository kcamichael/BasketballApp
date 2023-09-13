using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasketballApp.Data.Entities
{
    public class PlayerEntity
    {
        [Key]
        [Required]
        public int ID { get; set; }
        [Required]
        [MaxLength(100)]
        public string Name { get; set; } = string.Empty;
        [Required]
        public int Number { get; set; }
        [MaxLength(250)]
        public string HighSchool { get; set; } = string.Empty;
        public int Height { get; set; }
        public int Weight { get; set; }
        [Required]
        public int CollegeId { get; set; }

        [ForeignKey(nameof(CollegeId))]
        public virtual CollegeEntity College { get; set; }

        [Required]
        public int PositionId { get; set; }

        [ForeignKey(nameof(PositionId))]
        public virtual PositionEntity Position { get; set; }

    }
}
