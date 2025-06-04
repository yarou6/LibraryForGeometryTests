namespace LibraryForGeometryTests
{
    public class Point
    {
        public double X { get; }
        public double Y { get; }

        public Point(double x, double y)
        {
            if (this == null) throw new ArgumentNullException();
            X = x;
            Y = y;
        }

        public override string ToString() => $"({X}, {Y})";
    }
}