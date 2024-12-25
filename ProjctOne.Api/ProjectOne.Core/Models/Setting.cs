using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectOne.Core.Models
{
    public class Setting
    {
        [Key]
        public int SettingId { get; set; }

        [Required,ForeignKey("ProfileInfo")]
        public int ProfileId { get; set; }

        public virtual ProfileInfo ProfileInfo { get; set; }

        [Required,MaxLength(50)]
        public String Language { get; set; }

        [Required,MaxLength (50)]
        public String Theme { get; set; } 





    }
}
