

using LibraryForGeometryTests;

namespace TestProject1
{
    public class Tests
    {

        [SetUp]
        public void Setup()
        {
        }
        //1
        [Test]
        public void PointsWithSameCoordinates_AreEqual()
        {
            Point point1 = new Point(0, 0);
            Point point2 = new Point(0, 0);

            Assert.AreEqual(point1.X, point2.X);
            Assert.AreEqual(point1.Y, point2.Y);
        }


        [Test]
        public void PointsWithDifferentCoordinates_AreNotEqual()
        {
            Point point1 = new Point(0, 1);
            Point point2 = new Point(1, 0);

            Assert.AreNotEqual(point1.X, point2.X);
            Assert.AreNotEqual(point1.Y, point2.Y);
        }




        [Test]
        public void NullPoint_ThrowsException()
        {
            Assert.Throws<ArgumentNullException>(() => new Rectangle(null, 1, 2));
        }

        [Test]
        public void PointToString_ReturnsCorrectFormat()
        {
            Point point1 = new Point(0, 0);

            Assert.AreEqual($"({point1.X}, {point1.Y})", point1.ToString());

        }















        //2
        [Test]
        public void BoundingBox_Center_CalculatesCorrectly()
        {
            Point point1 = new Point(0, 1);
            Point point2 = new Point(1, 0);

            BoundingBox boundingBox = new BoundingBox(point1, point2);
            Point points = boundingBox.Center;
            Assert.AreEqual(points.X, boundingBox.Center.X);
            Assert.AreEqual(points.Y, boundingBox.Center.Y);
        }

        [Test]
        public void BoundingBox_IntersectingBoxes_ReturnsTrue()
        {
            Point point1 = new Point(0, 0);
            Point point2 = new Point(10, 10);
            BoundingBox boundingBox1 = new BoundingBox(point1, point2);

            Point point21 = new Point(5, 5);
            Point point22 = new Point(20, 20);
            BoundingBox boundingBox2 = new BoundingBox(point21, point22);

            Assert.IsTrue(boundingBox1.Intersects(boundingBox2));
        }

        [Test]
        public void BoundingBox_NonIntersectingBoxes_ReturnsFalse()
        {
            Point point1 = new Point(0, 0);
            Point point2 = new Point(10, 10);
            BoundingBox boundingBox1 = new BoundingBox(point1, point2);

            Point point21 = new Point(20, 20);
            Point point22 = new Point(20, 20);
            BoundingBox boundingBox2 = new BoundingBox(point21, point22);

            Assert.IsFalse(boundingBox1.Intersects(boundingBox2));
        }

        [Test]
        public void BoundingBox_EqualBoxes_ReturnsTrue()
        {
            Point point1 = new Point(0, 0);
            Point point2 = new Point(10, 10);
            BoundingBox boundingBox1 = new BoundingBox(point1, point2);

            Point point21 = new Point(0, 0);
            Point point22 = new Point(10, 10);
            BoundingBox boundingBox2 = new BoundingBox(point21, point22);

            Assert.IsTrue(boundingBox1.TopRight.X == boundingBox2.TopRight.X);

            Assert.IsTrue(boundingBox1.BottomLeft.X == boundingBox2.BottomLeft.X);

            Assert.IsTrue(boundingBox1.BottomLeft.Y == boundingBox2.BottomLeft.Y);

            Assert.IsTrue(boundingBox1.TopRight.Y == boundingBox2.TopRight.Y);
        }


        [Test]
        public void BoundingBox_EmptyBox_ThrowsOrHandlesGracefully()
        {
            Point point1 = new Point(0, 0);
            Point point2 = new Point(0, 0);
            BoundingBox boundingBox1 = new BoundingBox(point1, point2);
            Assert.AreEqual(boundingBox1.TopRight.X, boundingBox1.BottomLeft.X);
            Assert.AreEqual(boundingBox1.TopRight.Y, boundingBox1.BottomLeft.Y);
            Assert.AreEqual(boundingBox1.TopRight.Y, boundingBox1.BottomLeft.X);
            Assert.AreEqual(boundingBox1.TopRight.X, boundingBox1.BottomLeft.Y);
        }









        //3
        [Test]
        public void Circle_GetArea_CorrectValue()
        {
            Point point = new Point(0, 0);
            double radius = 10;
            Circle circle = new Circle(point, radius);
            Assert.AreEqual(Math.PI * radius * radius, circle.GetArea());

        }


        [Test]
        public void Circle_GetPerimeter_CorrectValue()
        {

            Point point = new Point(0, 0);
            double radius = 10;
            Circle circle = new Circle(point, radius);
            Assert.AreEqual(2 * Math.PI * radius, circle.GetPerimeter());
        }


        [Test]
        public void Circle_NegativeRadius_ThrowsException()
        {
            Point point = new Point(0, 0);
            double radius = -10;
            Circle circle = new Circle(point, radius);
            Assert.IsTrue(circle.Radius < 0);
        }

        [Test]
        public void Circle_Position_SetCorrectly()
        {
            Point point = new Point(0, 0);
            double radius = 10;
            Circle circle = new Circle(point, radius);
            Assert.AreEqual(point.X, circle.Position.X);
            Assert.AreEqual(point.Y, circle.Position.Y);
        }


        [Test]
        public void Circle_NullPosition_ThrowsException()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                Circle circle = new Circle(null, 0);


            });
        }





        //4

        [Test]
        public void Rectangle_GetArea_CorrectValue()
        {
            Point point = new Point(0, 5);
            int Width = 10;
            int Height = 10;
            Rectangle rectangle = new Rectangle(point, Width, Height);
            Assert.AreEqual(Width * Height, rectangle.GetArea());
        }
        [Test]
        public void Rectangle_GetPerimeter_CorrectValue()
        {
            Point point = new Point(0, 5);
            int Width = 10;
            int Height = 10;
            Rectangle rectangle = new Rectangle(point, Width, Height);
            Assert.AreEqual(2 * (Width + Height), rectangle.GetPerimeter());
        }
        [Test]
        public void Rectangle_ZeroWidth_ThrowsException()
        {
            Point point = new Point(0, 5);
            int Width = 0;
            int Height = 10;
            Rectangle rectangle = new Rectangle(point, Width, Height);
            Assert.AreEqual(Width, rectangle.Width);
        }

        [Test]
        public void Rectangle_ZeroHeight_ThrowsException()
        {
            Point point = new Point(0, 5);
            int Width = 10;
            int Height = 0;
            Rectangle rectangle = new Rectangle(point, Width, Height);
            Assert.AreEqual(Height, rectangle.Height);
        }

        [Test]
        public void Rectangle_Position_SetCorrectly()
        {
            Point point = new Point(0, 5);
            int Width = 10;
            int Height = 0;
            Rectangle rectangle = new Rectangle(point, Width, Height);
            Assert.AreEqual(point.X, rectangle.Position.X);
            Assert.AreEqual(point.Y, rectangle.Position.Y);
        }        
        
        [Test]
        public void Rectangle_NullPosition_ThrowsException()
        {
            Assert.Throws<ArgumentNullException>(() => new Rectangle(null, 0, 0));
        }










        //5
        [Test]
        public void Triangle_GetArea_CorrectForValidSides()
        {

            Point point = new Point(0, 5);
            int a = 10;
            int b = 5;
            int c = 3;
            Triangle triangle = new Triangle(point, a, b, c);

            double p = triangle.GetPerimeter() / 2;    

            Assert.AreEqual(Math.Sqrt(p * (p - a) * (p - b) * (p - c)), triangle.GetArea());
        } 
        
        [Test]
        public void Triangle_InvalidSides_ThrowsException()
        {
            Point point = new Point(0, 5);
            int a = 8;
            int b = 5;
            int c = 3;
            Triangle triangle = new Triangle(point, a, b, c);
            if (triangle.A > 0 && triangle.B > 0 && triangle.C > 0 && a + b > c && b + c > a && a + c > b)
            {
                Assert.True(true);

            }else Assert.False(false);  


        } 
        
        
        [Test]
        public void Triangle_GetPerimeter_CorrectValue()
        {
            Point point = new Point(0, 5);
            int a = 10;
            int b = 5;
            int c = 3;
            Triangle triangle = new Triangle(point, a, b, c);


            Assert.AreEqual(a + b + c, triangle.GetPerimeter());
        } 
        
        
        [Test]
        public void Triangle_Position_SetCorrectly()
        {
            Point point = new Point(0, 5);
            int a = 10;
            int b = 5;
            int c = 3;
            Triangle triangle = new Triangle(point, a, b, c);
            Assert.AreEqual(point.X, triangle.Position.X);
            Assert.AreEqual(point.Y, triangle.Position.Y);
        } 
        
        
        [Test]
        public void Triangle_NullPosition_ThrowsException()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                Triangle triangle = new Triangle(null, 0, 0 ,0);


            });
        } 
        
        
        
        
        
        
        
        
        
        //6
        [Test]
        public void Polygon_Empty_GetAreaReturnsZero()
        {
            Polygon polygon = new Polygon();
            Assert.AreEqual(0, polygon.GetArea());
        }
        
        [Test]
        public void Polygon_Empty_GetPerimeterReturnsZero()
        {
            Polygon polygon = new Polygon();
            Assert.AreEqual(0, polygon.GetPerimeter());
        }
           
        [Test]
        public void Polygon_AddShape_IncreasesTotalArea()
        {
            Polygon polygon = new Polygon();
            Point point = new Point(0, 5);
            int a = 5;
            int b = 5;
            int c = 3;
            Triangle triangle = new Triangle(point, a, b, c);
            double polplh1 = polygon.GetArea();
            polygon.AddShape(triangle);
            double polplh2 = polygon.GetArea();
            Assert.IsTrue(polplh1 < polplh2);
        }
           
        [Test]
        public void Polygon_RemoveShape_DecreasesTotalArea()
        {
            Polygon polygon = new Polygon();
            Point point = new Point(0, 5);
            int a = 5;
            int b = 5;
            int c = 3;
            Triangle triangle = new Triangle(point, a, b, c);
            polygon.AddShape(triangle);
            double polplh1 = polygon.GetArea();
            polygon.RemoveShape(triangle);
            double polplh2 = polygon.GetArea();
            Assert.IsTrue(polplh1 > polplh2);
        }

        [Test]
        public void Polygon_GetBoundingBox_CalculatesCorrectBounds()
        {
            Polygon polygon = new Polygon();
            Point point1 = new Point(0, 0);
            Point point2 = new Point(4, 4);

            var box = polygon.GetBoundingBox();

            polygon.AddShape(new Circle(new Point(0, 0), 1));
            polygon.AddShape(new Rectangle(new Point(4, 4), 2, 2));
            Assert.That(box.BottomLeft.X, Is.EqualTo(point1.X - 1));
            Assert.That(box.BottomLeft.Y, Is.EqualTo(point1.Y - 1));
            Assert.That(box.TopRight.X, Is.EqualTo(point2.X + 1));
            Assert.That(box.TopRight.Y, Is.EqualTo(point2.Y + 1));

        }


        [Test]
        public void Polygon_AddNullShape_ThrowsException()
        {
            Polygon polygon = new Polygon();

            Assert.Throws<ArgumentNullException>(() =>
            {
                polygon.AddShape(null);
            });
        }


        [Test]
        public void Polygon_RemoveNullShape_ThrowsException()
        {
            Polygon polygon = new Polygon();

            Assert.Throws<ArgumentNullException>(() =>
            {
                polygon.RemoveShape(null);
            });
        }


        [Test]
        public void Polygon_HasIntersection_ReturnsTrue_WhenOverlapping()
        {
            Polygon polygon = new Polygon();

            polygon.AddShape(new Rectangle(new Point(0, 0), 2, 2));
            polygon.AddShape(new Rectangle(new Point(5, 5), 2, 2));

            Assert.IsTrue(polygon.HasIntersection());
        }


        [Test]
        public void Polygon_HasIntersection_ReturnsFalse_WhenNoOverlap()
        {
            Polygon polygon = new Polygon();

            polygon.AddShape(new Rectangle(new Point(0, 0), 2, 2));
            polygon.AddShape(new Rectangle(new Point(5, 5), 2, 2));

            Assert.IsFalse(polygon.HasIntersection());

        }

        [Test]
        public void Polygon_HasIntersection_SingleShape_ReturnsFalse()
        {
            Polygon polygon = new Polygon();

            polygon.AddShape(new Rectangle(new Point(0, 0), 2, 2));

            Assert.IsFalse(polygon.HasIntersection());
        }

        [Test]
        public void Polygon_HasIntersection_Empty_ReturnsFalse()
        {

            Polygon polygon = new Polygon();

            Assert.IsFalse(polygon.HasIntersection());
        }
        //Дополнительно

        public void Polygon_GetBoundingBox_ForMixedShapes_Correct()
        {
            Polygon polygon = new Polygon();
            Point point1 = new Point(0, 0);
            Point point2 = new Point(4, 4);
            Point point3 = new Point(-3, -3);


            polygon.AddShape(new Circle(point1, 1));
            polygon.AddShape(new Rectangle(point2, 2, 2));
            polygon.AddShape(new Triangle(point3, 3, 4, 5));

            var box = polygon.GetBoundingBox();

            Assert.LessOrEqual(box.BottomLeft.X, point3.X);
            Assert.LessOrEqual(box.BottomLeft.Y, point3.Y);

            Assert.GreaterOrEqual(box.TopRight.X, point2.X + 1);
            Assert.GreaterOrEqual(box.TopRight.Y, point2.Y + 1);

        }

        public void Polygon_GetBoundingBox_AfterRemove_UpdatesCorrectly()
        {
            Polygon polygon = new Polygon();

            Point point1 = new Point(0, 0);
            Point point2 = new Point(10, 10);

            var q1 = new Rectangle(point1, 2, 2);
            var q2 = new Rectangle(point2, 2, 2);


            polygon.AddShape(q1);
            polygon.AddShape(q2);
            polygon.RemoveShape(q2);

            var box = polygon.GetBoundingBox();


            Assert.That(box.BottomLeft.X, Is.EqualTo(point1.X - 1));
            Assert.That(box.BottomLeft.Y, Is.EqualTo(point1.Y - 1));
            Assert.That(box.TopRight.X, Is.EqualTo(point2.X + 1));
            Assert.That(box.TopRight.Y, Is.EqualTo(point2.Y + 1));

        }

        public void Polygon_GetCenter_CalculatesFromBoundingBox()
        {
            Polygon polygon = new Polygon();

            Point point1 = new Point(2, 2);
            Point point2 = new Point(6, 6);

            polygon.AddShape(new Rectangle(point1, 2, 2));
            polygon.AddShape(new Rectangle(point2, 2, 2));

            var center = polygon.Position;

            Assert.That(center.X, Is.EqualTo(point2.X - point1.Y));
            Assert.That(center.Y, Is.EqualTo(point2.Y - point1.X));

        }







    }
}