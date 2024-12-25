using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectOne.Core.Models
{
    public class dtoProfileInfo
    {
        [Required]
        public String UserId { get; set; }

        public string Gender { get; set; }

        [Required]
        public DateTime BirthDay { get; set; }

        
        [Required, Range(50, 300, ErrorMessage = "Range should be between 50 and 300")]
        public int Height { get; set; }


        [Required, Range(50, 300, ErrorMessage = "Range should be between 50 and 300")]
        public int Weight { get; set; }


        [Required]
        public String FitnessLevel { get; set; }

        [Required, MaxLength(100, ErrorMessage = "MaxLength is 100")]
        public String FitnessGoal { get; set; }

    }
}
