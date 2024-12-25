using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectOne.Core.Models
{
    public class dtoFeedBack
    {
        [Required]
        public String UserId { get; set; }
        [Required]
        public int SessionId { get; set; }

        [Required, MaxLength(200)]
        public String Comment { get; set; }

        [Required]
        public double Rating { get; set; }
    }
}
