using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Bageriet.Models
{
    public class Products
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public bool Visible { get; set; }

        public List<Comments> Comments { get; set; }
        public List<Ratings> Ratings { get; set; }

        public Products() { }
        public Products(int Id, string Name, string Description, string Image, bool Visible = false) {
            this.Id = Id;
            this.Name = Name;
            this.Description = Description;
            this.Image = "/images/products/" + Image;
            this.Visible = Visible;
        }
    }
}
