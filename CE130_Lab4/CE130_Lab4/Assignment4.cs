abstract class Shape
{
    public abstract double CalculateArea();
}
class Circle : Shape
{
    public double Radius { get; set; }
    public override double CalculateArea()
    {
        return Math.PI * Radius * Radius;
    }
}
class Rectangle : Shape
{
    public double Length { get; set; }
    public double Width { get; set; }
    public override double CalculateArea()
    {
        return Length * Width;
    }
}
class Assignment4
{
    public static void Run()
    {
        Console.WriteLine("Shape Area Calculator");
        Console.Write("Enter radius of circle: ");
        double radius = Convert.ToDouble(Console.ReadLine());
        Circle circle = new Circle();
        circle.Radius = radius;
        Console.WriteLine($"Area of Circle: {circle.CalculateArea():F2}");
        Console.WriteLine();
        Console.Write("Enter length of rectangle: ");
        double length = Convert.ToDouble(Console.ReadLine());
        Console.Write("Enter width of rectangle: ");
        double width = Convert.ToDouble(Console.ReadLine());
        Rectangle rectangle = new Rectangle();
        rectangle.Length = length;
        rectangle.Width = width;
        Console.WriteLine($"Area of Rectangle: {rectangle.CalculateArea():F2}");
    }
}