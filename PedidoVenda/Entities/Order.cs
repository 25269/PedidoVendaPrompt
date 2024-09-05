using System;
using PedidoVendaPrompt.Entities.Enums;
using System.Text;
using System.Globalization;

namespace PedidoVendaPrompt.Entities
{
    internal class Order
    {
        public DateTime Moment { get; set; }
        public OrderStatus Status { get; set; }
        List<OrderItem> items { get; set; } = new List<OrderItem>();
        List<Product> products { get; set; } = new List<Product>();
        public Client Client { get; set; }

        public Order() { }

        public Order(DateTime moment, OrderStatus status)
        {
            this.Moment = moment;
            this.Status = status;
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
            sb.AppendLine($"Order moment: {Moment}");
            sb.AppendLine($"Order status: {Status.ToString()}");
            sb.AppendLine($"Client: {Client.Name} ({Client.BirthDate}) - {Client.Email} ");
            sb.AppendLine("Order items: ");

            foreach (OrderItem item in items)
            {
               sb.AppendLine($"{item.Product.Name}, R$ {item.Product.Price},  Quantity: {item.Quantity}, Subtotal: R$ " + (item.subTotal()).ToString("F2", CultureInfo.InvariantCulture));
            }

            sb.AppendLine("Total price: R$ " + total().ToString("F2", CultureInfo.InvariantCulture));

            return sb.ToString();
        }
    }
}

