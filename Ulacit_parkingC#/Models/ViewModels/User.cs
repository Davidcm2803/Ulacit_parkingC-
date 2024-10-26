using System;

namespace Ulacit_parkingC_.Models
{
    public class User
    {
        public int id { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public DateTime date_of_birth { get; set; }
        public string identification { get; set; }
        public string card_number { get; set; }
        public string role { get; set; }
        public string password { get; set; }
        public char PasswordChanged { get; set; } // Cambiar a char si es necesario
        public char IsActive { get; set; } // Cambiar a char si es necesario
    }

}

