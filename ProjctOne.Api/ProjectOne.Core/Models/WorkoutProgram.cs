using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectOne.Core.Models
{
    public class WorkoutProgram
    {
        [Key]
        public int ProgramId { get; set; }
        [Required,MaxLength(100,ErrorMessage ="maxLength is 100")]
        public string ProgramName { get; set; }
        [Required]
        public string ProgramDescription { get; set; }
        
        [Required,MaxLength(50,ErrorMessage = "maxLength is 50")]
        public String DifficultyLevel { get; set; }

        public virtual ICollection<Program_Exercise> Program_Exercises { get; set; }
    }
}
