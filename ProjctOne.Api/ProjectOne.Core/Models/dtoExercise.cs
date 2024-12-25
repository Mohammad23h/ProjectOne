using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectOne.Core.Models
{
    public class dtoExercise
    {
        [Required, MaxLength(100)]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public int CaloreiBurn { get; set; }

        [Required]
        public int NutritionValue { get; set; }

        [Required]
        public string ImageURL { get; set; }
    }
}
