using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PedidoVenda.Entities
{
    internal class OrderItem
    {
        public int quantity { get; set; }
        public double price { get; set; }
        public Product product { get; set; }

        public OrderItem() { }

        public OrderItem (int quantity, double price)
        {
            this.quantity = quantity;
            this.price = price;
        }

        public double subTotal()
        {
            return quantity * price;
        }
    }
}
