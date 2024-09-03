using System;
using PedidoVenda.Entities.Enums;
using System.Text;
using System.Globalization;

namespace PedidoVenda.Entities
{
    internal class Order
    {
        public DateTime moment { get; set; }
        public OrderStatus status { get; set; }
        List<OrderItem> items { get; set; } = new List<OrderItem>();
        List<Product> products { get; set; } = new List<Product>();
        public Client client { get; set; }

        public Order() { }

        public Order(DateTime moment, OrderStatus status)
        {
            this.moment = moment;
            this.status = status;
        }

        public void addItem(OrderItem item)
        {
            items.Add(item);
        }

        public void removeItem(OrderItem item)
        {
            items.Remove(item);
        }

        public double total()
        {
            double totalOrdem = 0;

            foreach (OrderItem item in items)
            {
                totalOrdem += item.subTotal();
            }
            return totalOrdem;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Order Summary: ");
            sb.AppendLine($"Order moment: {moment}");
            sb.AppendLine($"Order status: {status.ToString()}");
            sb.AppendLine($"Client: {client.name} ({client.birthDate}) - {client.email} ");
            sb.AppendLine("Order items: ");

            foreach (OrderItem item in items)
            {
               sb.AppendLine($"{item.product.name}, R$ {item.product.price},  Quantity: {item.quantity}, Subtotal: R$ " + (item.subTotal()).ToString("F2", CultureInfo.InvariantCulture));
            }

            sb.AppendLine("Total price: R$ " + total().ToString("F2", CultureInfo.InvariantCulture));

            return sb.ToString();
        }
    }
}

