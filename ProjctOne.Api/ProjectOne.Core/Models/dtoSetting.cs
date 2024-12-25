using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectOne.Core.Models
{
    public class dtoSetting
    {
        
        [Required]
        public int ProfileId { get; set; }

        [Required, MaxLength(50)]
        public String Language { get; set; }

        [Required, MaxLength(50)]
        public String Theme { get; set; }
    }
}
