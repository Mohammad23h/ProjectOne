using Castle.Components.DictionaryAdapter;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KeyAttribute = System.ComponentModel.DataAnnotations.KeyAttribute;

namespace ProjectOne.Core.Models
{
    public class Program_Exercise
    {
        [Key]
        public int Program_ExerciseId { get; set; }
        [Required,ForeignKey("Program")]
        public int ProgramId { get; set; }
        
        public virtual WorkoutProgram Program { get; set; }

        [Required, ForeignKey("Exercise")]
        public int ExerciseId { get; set; }

        public virtual Exercise Exercise { get; set; }


    }
}
