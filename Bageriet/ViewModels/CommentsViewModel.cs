using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Bageriet.ViewModels
{
    public class CommentsViewModel
    {
        public int Id { get; set; }
        [Required]
        public string Text { get; set; }
        public int ProductId { get; set; }
    }
}
