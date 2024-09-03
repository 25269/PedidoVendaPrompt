using System;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace PedidoVenda.Entities
{
    internal class Client
    {
        public string name { get; set; }
        public string email { get; set; }
        public DateOnly birthDate { get; set; }

        public Client() { }

        public Client(string name, string email, DateOnly birthDate)
        {
            this.name = name;
            this.email = email;
            this.birthDate = birthDate;
        }
    }
}
