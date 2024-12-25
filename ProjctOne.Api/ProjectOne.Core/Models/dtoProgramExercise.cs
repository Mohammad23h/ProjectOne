using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectOne.Core.Models
{
    public class dtoProgramExercise
    {
        [Required]
        public int ProgramId { get; set; }
        [Required]
        public int ExerciseId { get; set; }
    }
}
