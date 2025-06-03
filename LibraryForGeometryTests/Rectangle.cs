namespace LibraryForGeometryTests
{
    public class Rectangle : IShapeWithPosition
    {
        public double Width { get; }
        public double Height { get; }
        public Point Position { get; }

        public Rectangle(Point position, double width, double height)
        {
            Position = position ?? throw new ArgumentNullException(nameof(position));
            Width = width;
            Height = height;
        }

        public double GetArea()
        {
            return Width * Height;
        }

        public double GetPerimeter()
        {
            return 2 * (Width + Height);
        }
    }
}