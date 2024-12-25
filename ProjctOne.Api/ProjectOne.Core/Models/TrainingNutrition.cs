using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectOne.Core.Models
{
    public class TrainingNutrition
    {
        [Key]
        public int TrainingNutritionId { get; set; }
        [Required, ForeignKey("Nutrition")]
        public int NutritionId { get; set; }
        public virtual Nutrition Nutrition { get; set; }

        [Required,ForeignKey("Session")]
        public int SessionId { get; set; }
        public virtual TrainingSession Session { get; set; }
    }
}
