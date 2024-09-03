using System;
using PedidoVenda.Entities;
using PedidoVenda.Entities.Enums;
using System.Globalization;

namespace PedidoVenda
{
    public class Program
    {
        static void Main(string[] args)
        {
            int qtyItems;

            Client client = new Client();
            Order order = new Order();
            
            Console.WriteLine("Enter cliente data: ");

            Console.Write("Name: ");
            client.name = Console.ReadLine();

            Console.Write("E-mail: ");
            client.email = Console.ReadLine();

            Console.Write("Birth Date (DD/MM/YYYY): ");
            client.birthDate = DateOnly.Parse(Console.ReadLine());

            order.client = client;

            Console.WriteLine("Enter order data: ");

            Console.Write("Status: ");
            OrderStatus status = Enum.Parse<OrderStatus>(Console.ReadLine());
            order.status = status;

            Console.Write("How many items to this order? ");
            qtyItems = int.Parse(Console.ReadLine());

            for (int i = 0; i < qtyItems; i++)
            {
                OrderItem orderItem = new OrderItem();
                Product product = new Product();

                Console.WriteLine($"Enter #{i + 1} item data: ");

                Console.Write("Product name: ");
                product.name = Console.ReadLine();

                Console.Write("Product price: ");
                product.price = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

                Console.Write("Quantity: ");
                orderItem.quantity = int.Parse(Console.ReadLine());

                orderItem.price = product.price;

                orderItem.product = product;

                order.addItem(orderItem);

                Console.WriteLine();
            }

            order.moment = DateTime.UtcNow;

            Console.WriteLine(order.ToString());
        }
    }
}