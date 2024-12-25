using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectOne.Core.Models
{
    public class Injurie
    {
        [Key]
        public int InjurieId { get; set; }

        [Required,ForeignKey("Profile")]
        public int ProfileId { get; set; }

        public virtual ProfileInfo Profile { get; set; }

        [Required,MaxLength(50)]
        public string InjurieName { get; set; }

        [Required,MaxLength(50)]
        public string InjurieType { get; set; }// هل المرض حالي ام منتهي

        [Required]
        public DateTime InjurieDate { get; set; }

        public DateTime HealingDate { get; set; }

        [MaxLength(200)]
        public string IInjurieDescription { get; set;}




    }
}
