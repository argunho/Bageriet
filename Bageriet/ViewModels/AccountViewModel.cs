using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Bageriet.ViewModels
{
    public class AccountViewModel
    {
        [Required]
        [Display(Name = "Namn")]
        public string Name { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "E-post")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "Lösenord {0} måste vara minst {2} och max {1} tecken långa.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Lösenord")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Bekräfta lösenord")]
        [Compare("Password", ErrorMessage = "Lösenordet och bekräftelseslösenordet matchar inte.")]
        public string ConfirmPassword { get; set; }

        [Display(Name = "Kom ihåg mig?")]
        public bool RememberMe { get; set; }
    }
}
