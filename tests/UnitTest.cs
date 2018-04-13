using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Proga;

namespace UnitTestShapes
{
    [TestClass]
    public class SquareTest
    {
        private TestContext contextInstance;

        public TestContext TestContext { get => contextInstance; set => contextInstance = value; }

        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV",
                    "|DataDirectory|\\test\\Square.csv", "Square#csv", DataAccessMethod.Sequential),
            DeploymentItem("Square.csv"), TestMethod]
        public void TestMethodSquarePerimeter()
        {
            //Arrange
            string points = TestContext.DataRow["Points"].ToString();
            double perimeter = double.Parse(TestContext.DataRow["Perimeter"].ToString());

            Point[] point = new Point[2];
            string[] inputPoints = points.Split(' ');
            for (int i = 0; i < 4; i += 2)  
            {
                point[i / 2] = new Point(Convert.ToInt32(inputPoints[i]), Convert.ToInt32(inputPoints[i + 1]));
            }

            //Act
            Square square = new Square(point[0], point[1]);

            //Assert
            Assert.AreEqual(perimeter, square.Perimeter);
        }

        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV",
                    "|DataDirectory|\\test\\Square.csv", "Square#csv", DataAccessMethod.Sequential),
            DeploymentItem("Square.csv"), TestMethod]
        public void TestMethodSquareArea()
        {
            //Arrange
            string points = TestContext.DataRow["Points"].ToString();
            double area = double.Parse(TestContext.DataRow["Area"].ToString());

            Point[] point = new Point[2];
            string[] inputPoints = points.Split(' ');
            for (int i = 0; i < 4; i += 2)
            {
                point[i / 2] = new Point(Convert.ToInt32(inputPoints[i]), Convert.ToInt32(inputPoints[i + 1]));
            }

            //Act
            Square square = new Square(point[0], point[1]);

            //Arrange
            Assert.AreEqual(area, square.Area);
        }
    }

    [TestClass]
    public class TriangleTest
    {
        private TestContext contextInstance;

        public TestContext TestContext { get => contextInstance; set => contextInstance = value; }

        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV",
                    "|DataDirectory|\\test\\Triangle.csv", "Triangle#csv", DataAccessMethod.Sequential),
            DeploymentItem("Triangle.csv"), TestMethod]
        public void TestMethodTrianglePerimeter()
        {
            string points = TestContext.DataRow["Points"].ToString();
            double perimeter = double.Parse(TestContext.DataRow["Perimeter"].ToString());

            Point[] point = new Point[3];
            string[] inputPoints = points.Split(' ');
            for (int i = 0; i < 6; i += 2)
            {
                point[i / 2] = new Point(Convert.ToInt32(inputPoints[i]), Convert.ToInt32(inputPoints[i + 1]));
            }

            //Act
            Triangle triangle = new Triangle(point[0], point[1], point[2]);

            //Assert
            Assert.AreEqual(perimeter, triangle.Perimeter);
        }

        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV",
                    "|DataDirectory|\\test\\Triangle.csv", "Triangle#csv", DataAccessMethod.Sequential),
            DeploymentItem("Triangle.csv"), TestMethod]
        public void TestMethodTriangleArea()
        {
            //Arrange
            string points = TestContext.DataRow["Points"].ToString();
            double area = double.Parse(TestContext.DataRow["Area"].ToString());

            Point[] point = new Point[3];
            string[] inputPoints = points.Split(' ');
            for (int i = 0; i < 6; i += 2)
            {
                point[i / 2] = new Point(Convert.ToInt32(inputPoints[i]), Convert.ToInt32(inputPoints[i + 1]));
            }

            //Act
            Triangle triangle = new Triangle(point[0], point[1], point[2]);

            //Arrange
            Assert.AreEqual(area, triangle.Area);
        }
    }
}
