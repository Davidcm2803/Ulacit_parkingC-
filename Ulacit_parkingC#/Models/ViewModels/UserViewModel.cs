using System;
using System.Collections.Generic;    
using System.ComponentModel.DataAnnotations;



    namespace Ulacit_parkingC_.Models.ViewModels
    {
    // Modelo de Vista
    public class UserViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Identification { get; set; }
        public string CardNumber { get; set; }
        public string Role { get; set; }
        public DateTime DateOfBirth { get; set; }
        public bool PasswordChanged { get; set; }
        public bool IsActive { get; set; }
    }


}


