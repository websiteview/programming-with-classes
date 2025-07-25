using System;

class Program
{
    static void Main(string[] args)
    {
        // Order 1 - USA
        Address addr1 = new Address("123 Apple St", "New York", "NY", "USA");
        Customer cust1 = new Customer("John Smith", addr1);
        Order order1 = new Order(cust1);
        order1.AddProduct(new Product("Laptop", "L123", 999.99, 1));
        order1.AddProduct(new Product("Mouse", "M456", 25.50, 2));

        // Order 2 - International
        Address addr2 = new Address("456 Elm Road", "Toronto", "Ontario", "Canada");
        Customer cust2 = new Customer("Sophie Lee", addr2);
        Order order2 = new Order(cust2);
        order2.AddProduct(new Product("Camera", "C789", 450.00, 1));
        order2.AddProduct(new Product("Tripod", "T321", 89.99, 1));
        order2.AddProduct(new Product("SD Card", "S654", 19.99, 2));

        // Display Order 1
        Console.WriteLine(order1.GetPackingLabel());
        Console.WriteLine(order1.GetShippingLabel());
        Console.WriteLine($"Total Cost: ${order1.GetTotalCost():F2}");
        Console.WriteLine();

        // Display Order 2
        Console.WriteLine(order2.GetPackingLabel());
        Console.WriteLine(order2.GetShippingLabel());
        Console.WriteLine($"Total Cost: ${order2.GetTotalCost():F2}");
    }
}
