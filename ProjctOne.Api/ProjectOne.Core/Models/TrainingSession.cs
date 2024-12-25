using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectOne.Core.Models
{
    public class TrainingSession
    {
        
        [Key]
        public int SessionId { get; set; }

        [Required, ForeignKey("User")]
        public String UserId { get; set; }

        [Required, ForeignKey("Program")]
        public int ProgramId { get; set; }


        public virtual AppUser User { get; set; }

        public virtual WorkoutProgram Program { get; set; }

        [Required]
        public DateTime StartTime { get; set; }

        [Required]
        public DateTime EndTime { get; set; }

        [Required]
        public string Status { get; set; }


        public virtual ICollection<FeedBack> FeedBacks { get; set; }
        public virtual ICollection<TrainingNutrition> TrainingNutritions { get; set; }
        
    }
}
