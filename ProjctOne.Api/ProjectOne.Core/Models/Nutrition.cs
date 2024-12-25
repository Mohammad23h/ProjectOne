using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectOne.Core.Models
{
    public class Nutrition
    {
        [Key]
        public int NutritionId { get; set; }

        [Required, ForeignKey("User")]
        public String UserId { get; set; }

        public virtual AppUser User { get; set; }
        
        [Required, MaxLength(50)]
        public string FoodName { get; set; }

        [Required]
        public int Calories { get; set; }

        [Required]
        public int Carbohydrates { get; set; }

        [Required]
        public int Proteins { get; set; }

        [Required]
        public int Fats { get; set;}

        public virtual ICollection<TrainingNutrition> TrainingNutritions { get; set; }

    }
}
