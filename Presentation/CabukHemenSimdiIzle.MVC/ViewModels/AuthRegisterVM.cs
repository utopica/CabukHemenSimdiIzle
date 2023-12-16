using System;
using CabukHemenSimdiIzle.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace CabukHemenSimdiIzle.MVC.ViewModels
{
	public class AuthRegisterVM
	{
       
        public string Email { get; set; }
      
        public string UserName { get; set; }
       
        public string Password { get; set; }
        
        public string FirstName { get; set; }
     
        public string SurName { get; set; }
        public DateTimeOffset? BirthDate { get; set; }
      
        public Gender Gender { get; set; }
    }
}

