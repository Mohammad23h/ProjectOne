using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectOne.Core.Models
{
    public class dtoInjurie
    {
        [Required]
        public int ProfileId { get; set; }
        [Required, MaxLength(50)]
        public string InjurieName { get; set; }

        [Required, MaxLength(50)]
        public string InjurieType { get; set; }// هل المرض حالي ام منتهي

        [Required]
        public DateTime InjurieDate { get; set; }

        public DateTime HealingDate { get; set; }

        [MaxLength(200)]
        public string IInjurieDescription { get; set; }


    }
}
