using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectOne.Core.Models
{
    public class dtoNutrition
    {
        [Required]
        public String UserId { get; set; }

        [Required, MaxLength(50)]
        public string FoodName { get; set; }

        [Required]
        public int Calories { get; set; }

        [Required]
        public int Carbohydrates { get; set; }

        [Required]
        public int Proteins { get; set; }

        [Required]
        public int Fats { get; set; }
    }
}
