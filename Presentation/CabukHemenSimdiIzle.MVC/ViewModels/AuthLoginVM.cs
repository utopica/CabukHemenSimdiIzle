using System;
using System.ComponentModel.DataAnnotations;

namespace CabukHemenSimdiIzle.MVC.ViewModels
{
	public class AuthLoginVM
	{
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }

    }
}

