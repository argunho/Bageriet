using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Bageriet.Models
{
    public class Comments
    {
        [Key]
        public int Id { get; set; }
        public Users User { get; set; }
        public string Text { get; set; }
        public DateTime Date { get; set; }
        public Products Product { get; set; }

        public Comments() {
            Date = DateTime.Now;
        }
    }
}
