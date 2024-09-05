using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PedidoVendaPrompt.Entities
{
    internal class OrderItem
    {
        public int Quantity { get; set; }
        public double Price { get; set; }
        public Product Product { get; set; }

        public OrderItem() { }

        public OrderItem (int quantity, double price)
        {
            this.Quantity = quantity;
            this.Price = price;
        }

        public double SubTotal()
        {
            return Quantity * Price;
        }
    }
}
