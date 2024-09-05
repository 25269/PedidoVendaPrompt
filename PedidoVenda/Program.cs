using System;
using PedidoVendaPrompt.Entities;
using PedidoVendaPrompt.Entities.Enums;
using System.Globalization;

namespace PedidoVendaPrompt
{
    public class Program
    {
        static void Main(string[] args)
        {
            int qtyItems;

            Client Client = new Client();
            Order Order = new Order();
            
            Console.WriteLine("Enter client data: ");

            Console.Write("Name: ");
            Client.Name = Console.ReadLine();

            Console.Write("E-mail: ");
            Client.Email = Console.ReadLine();

            Console.Write("Birth Date (DD/MM/YYYY): ");
            Client.BirthDate = DateOnly.Parse(Console.ReadLine());

            Order.Client = Client;

            Console.WriteLine("Enter order data: ");

            Console.Write("Status: ");
            OrderStatus status = Enum.Parse<OrderStatus>(Console.ReadLine());
            Order.Status = status;

            Console.Write("How many items to this order? ");
            qtyItems = int.Parse(Console.ReadLine());

            for (int i = 0; i < qtyItems; i++)
            {
                OrderItem orderItem = new OrderItem();
                Product product = new Product();

                Console.WriteLine($"Enter #{i + 1} item data: ");

                Console.Write("Product name: ");
                product.Name = Console.ReadLine();

                Console.Write("Product price: ");
                product.Price = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

                Console.Write("Quantity: ");
                orderItem.Quantity = int.Parse(Console.ReadLine());

                orderItem.Price = product.Price;

                orderItem.Product = product;

                Order.addItem(orderItem);

                Console.WriteLine();
            }

            Order.Moment = DateTime.UtcNow;

            Console.WriteLine(Order.ToString());
        }
    }
}