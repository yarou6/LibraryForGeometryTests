namespace LibraryForGeometryTests
{
    public class Triangle : IShapeWithPosition
    {
        public double A { get; }
        public double B { get; }
        public double C { get; }
        public Point Position { get; }

        public Triangle(Point position, double a, double b, double c)
        {
            Position = position ?? throw new ArgumentNullException(nameof(position));
            A = a;
            B = b;
            C = c;
        }

        public double GetArea()
        {
            double p = GetPerimeter() / 2;
            return Math.Sqrt(p * (p - A) * (p - B) * (p - C));
        }

        public double GetPerimeter()
        {
            return A + B + C;
        }
    }
}