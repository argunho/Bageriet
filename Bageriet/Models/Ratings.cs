using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Bageriet.Models
{
    public class Ratings
    {
        [Key]
        public int Id { get; set; }
        public int Rating { get; set; }
        public Users User { get; set; }
        public Products Product { get; set; }
    }
}
