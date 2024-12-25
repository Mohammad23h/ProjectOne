using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectOne.Core.Models
{
    public class dtoTrainingNutrition
    {
        [Required]
        public int NutritionId { get; set; }

        [Required]
        public int SessionId { get; set; }
    }
}
