using System;
using System.Collections.Generic;
using System.Linq;

namespace LINQLab
{
    class Customer
    {
        // Define CustomerId, Name and City Properties.
        public int CustomerId { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
    }

    class Order
    {
        public int OrderId { get; set; }
        public int CustomerId { get; set; }
        public string ProductName { get; set; }
        public string Category { get; set; }
        public double OrderAmount { get; set; }
    }

    class Sample_prog
    {
        public static void Run()
        {
            List<Customer> customers = new List<Customer>()
            {
                new Customer { CustomerId = 1, Name = "Amit Shah", City = "Ahmedabad" },
                new Customer { CustomerId = 2, Name = "Priya Patel", City = "Vadodara" },
                new Customer { CustomerId = 3, Name = "Rahul Mehta", City = "Ahmedabad" },
                new Customer { CustomerId = 4, Name = "Neha Desai", City = "Surat" },
                new Customer { CustomerId = 5, Name = "Karan Shah", City = "Ahmedabad" }
            };

            List<Order> orders = new List<Order>()
            {
                new Order { OrderId = 101, CustomerId = 1, ProductName = "Laptop", Category = "Electronics", OrderAmount = 65000 },
                new Order { OrderId = 102, CustomerId = 1, ProductName = "Mouse", Category = "Electronics", OrderAmount = 1500 },
                new Order { OrderId = 103, CustomerId = 2, ProductName = "Mobile Phone", Category = "Electronics", OrderAmount = 30000 },
                new Order { OrderId = 104, CustomerId = 3, ProductName = "Headphones", Category = "Electronics", OrderAmount = 5000 },
                new Order { OrderId = 105, CustomerId = 3, ProductName = "Monitor", Category = "Electronics", OrderAmount = 22000 },
                new Order { OrderId = 106, CustomerId = 4, ProductName = "Keyboard", Category = "Electronics", OrderAmount = 3000 },
                new Order { OrderId = 107, CustomerId = 5, ProductName = "Tablet", Category = "Electronics", OrderAmount = 45000 },
                new Order { OrderId = 108, CustomerId = 5, ProductName = "Smart Watch", Category = "Electronics", OrderAmount = 12000 }
            };

            // ==========================================================
            // Write LINQ queries below
            // ==========================================================

            // Query 1:
            // Display the names of all customers along with the products they have ordered.
            // (Use Join)

            Console.WriteLine("Query 1: Customer Names and Products Ordered");
            Console.WriteLine("---------------------------------------------");

            var customerOrders = customers.Join(
                orders,
                customer => customer.CustomerId,
                order => order.CustomerId,
                (customer, order) => new
                {
                    CustomerName = customer.Name,
                    ProductName = order.ProductName
                }
            );

            foreach (var item in customerOrders)
            {
                Console.WriteLine(
                    $"Customer: {item.CustomerName}, Product: {item.ProductName}"
                );
            }


            // Query 2:
            // Display the details of the first order whose amount is greater than ₹20,000.
            // (Use First() or FirstOrDefault())

            Console.WriteLine("\nQuery 2: First Order Greater Than ₹20,000");
            Console.WriteLine("---------------------------------------------");

            var firstLargeOrder = orders.FirstOrDefault(
                order => order.OrderAmount > 20000
            );

            if (firstLargeOrder != null)
            {
                Console.WriteLine($"Order ID: {firstLargeOrder.OrderId}");
                Console.WriteLine($"Customer ID: {firstLargeOrder.CustomerId}");
                Console.WriteLine($"Product: {firstLargeOrder.ProductName}");
                Console.WriteLine($"Category: {firstLargeOrder.Category}");
                Console.WriteLine($"Amount: ₹{firstLargeOrder.OrderAmount}");
            }
            else
            {
                Console.WriteLine("No order found.");
            }


            // Query 3:
            // Display all customers from Ahmedabad along with the total amount
            // they have spent on orders.
            // (Use Join, Where, GroupBy, and Sum)

            Console.WriteLine("\nQuery 3: Ahmedabad Customers and Total Spending");
            Console.WriteLine("---------------------------------------------");

            var ahmedabadCustomers = customers
                .Join(
                    orders,
                    customer => customer.CustomerId,
                    order => order.CustomerId,
                    (customer, order) => new
                    {
                        CustomerId = customer.CustomerId,
                        CustomerName = customer.Name,
                        City = customer.City,
                        OrderAmount = order.OrderAmount
                    }
                )
                .Where(x => x.City == "Ahmedabad")
                .GroupBy(x => new
                {
                    x.CustomerId,
                    x.CustomerName,
                    x.City
                })
                .Select(group => new
                {
                    CustomerName = group.Key.CustomerName,
                    City = group.Key.City,
                    TotalAmount = group.Sum(x => x.OrderAmount)
                });

            foreach (var customer in ahmedabadCustomers)
            {
                Console.WriteLine(
                    $"Customer: {customer.CustomerName}, " +
                    $"City: {customer.City}, " +
                    $"Total Spent: ₹{customer.TotalAmount}"
                );
            }


            // Query 4:
            // Display the customer who has placed the highest-value order,
            // along with the product name and order amount.
            // (Use Join and OrderByDescending())

            Console.WriteLine("\nQuery 4: Customer with Highest-Value Order");
            Console.WriteLine("---------------------------------------------");

            var highestOrder = customers
                .Join(
                    orders,
                    customer => customer.CustomerId,
                    order => order.CustomerId,
                    (customer, order) => new
                    {
                        CustomerName = customer.Name,
                        ProductName = order.ProductName,
                        OrderAmount = order.OrderAmount
                    }
                )
                .OrderByDescending(x => x.OrderAmount)
                .FirstOrDefault();

            if (highestOrder != null)
            {
                Console.WriteLine($"Customer: {highestOrder.CustomerName}");
                Console.WriteLine($"Product: {highestOrder.ProductName}");
                Console.WriteLine($"Order Amount: ₹{highestOrder.OrderAmount}");
            }

            Console.ReadKey();
        }
    }
}