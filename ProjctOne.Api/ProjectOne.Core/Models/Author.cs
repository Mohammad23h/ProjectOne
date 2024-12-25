using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ProjectOne.Core.Models
{
    public class Author
    {

        public int Id { get; set; }
        [Required,MaxLength(150)]
        public string Name { get; set; }
    }
}
