using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Bageriet.Models
{
    public class Users : IdentityUser
    {

        [Required]
        public string Name { get; set; }

        public DateTime Date { get; set; }

        public Users() {
            Date = DateTime.Now;
        }
    }
}
