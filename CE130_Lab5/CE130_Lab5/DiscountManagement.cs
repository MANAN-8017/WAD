
class Product
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Category { get; set; }
    public double Price { get; set; }
    public double DiscountPercentage { get; set; }
    public Product(int id, string name, string category,
                   double price, double discountPercentage)
    {
        Id = id;
        Name = name;
        Category = category;
        Price = price;
        DiscountPercentage = discountPercentage;
    }
}
class DiscountManagement
{
    public static void Run()
    {
        List<Product> products = new List<Product>
        {
            new Product(1, "Monitor", "Electronics", 50000, 10),
            new Product(2, "Keyboard", "Electronics", 10000, 8),
            new Product(3, "Mouse", "Electronics", 5000, 5),
            new Product(4, "Laptop", "Electronics", 75000, 15)
        };
        
        Func<Product, double> calculateDiscount =
            product => product.Price * product.DiscountPercentage / 100;
            
        Func<Product, double> calculateFinalPrice =
            product => product.Price - calculateDiscount(product);
            
        Action<Product> displayProduct = product =>
        {
            double discountAmount = calculateDiscount(product);
            double finalPrice = calculateFinalPrice(product);
            Console.WriteLine($"Product ID          : {product.Id}");
            Console.WriteLine($"Product Name        : {product.Name}");
            Console.WriteLine($"Category            : {product.Category}");
            Console.WriteLine($"Original Price      : {product.Price}");
            Console.WriteLine($"Discount Percentage : {product.DiscountPercentage}%");
            Console.WriteLine($"Discount Amount     : {discountAmount}");
            Console.WriteLine($"Final Price         : {finalPrice}");
            Console.WriteLine();
        };
        Console.WriteLine("Discount Management System");
        Console.WriteLine();
        foreach (Product product in products)
        {
            displayProduct(product);
        }
    }
}