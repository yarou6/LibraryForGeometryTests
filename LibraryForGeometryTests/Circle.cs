namespace LibraryForGeometryTests
{
    public class Circle : IShapeWithPosition
    {
        public double Radius { get; }
        public Point Position { get; }

        public Circle(Point position, double radius)
        {
            Position = position ?? throw new ArgumentNullException(nameof(position));
            Radius = radius;
        }

        public double GetArea()
        {
            return Math.PI * Radius * Radius;
        }

        public double GetPerimeter()
        {
            return 2 * Math.PI * Radius;
        }
    }
}