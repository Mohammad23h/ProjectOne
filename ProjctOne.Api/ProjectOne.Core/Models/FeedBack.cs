using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectOne.Core.Models
{
    public class FeedBack
    {
        [Key]
        public int FeedBackId { get; set; }

        [Required,ForeignKey("User")]
        public String UserId { get; set; }
        [Required,ForeignKey("Session")]
        public int SessionId { get; set; }

        public virtual AppUser User { get; set; }

        public virtual TrainingSession Session { get; set; }

        [Required,MaxLength(200)]
        public String Comment { get; set; }

        [Required]
        public double Rating { get; set; }
    }
}
