using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectOne.Core.Models
{
    public class dtoLogin
    {
        [Required]
        public string userName { get; set; }

        [Required]
        public string password { get; set; }

    }
}
