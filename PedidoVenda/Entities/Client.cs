using System;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace PedidoVendaPrompt.Entities
{
    internal class Client
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public DateOnly BirthDate { get; set; }

        public Client() { }

        public Client(string name, string email, DateOnly birthDate)
        {
            this.Name = name;
            this.Email = email;
            this.BirthDate = birthDate;
        }
    }
}
