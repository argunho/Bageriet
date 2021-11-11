using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Bageriet.Models
{
    public class Roles
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Users> User { get; set; }

        public Roles(int Id, string Name) {
            this.Id = Id;
            this.Name = Name;
        }
    }
}
