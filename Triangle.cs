using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proga
{
    public class Triangle:IShape, IInputOutput,IComparable,ICloneable
    {
        private const int numberOfPoints = 3;
        Point[] point = new Point[numberOfPoints];

        public double Perimeter
        {
            get
            {
                double perimeter;
                perimeter = point[0].Distance(point[1]) + point[0].Distance(point[2]) + point[1].Distance(point[2]);
                perimeter = Math.Round(perimeter, 2);
                return perimeter;
            }
        }

        public double Area
        {
            get
            {
                double aSide = point[0].Distance(point[1]);
                double bSide = point[0].Distance(point[2]);
                double cSide = point[1].Distance(point[2]);
                double semiPerimeter = Perimeter / 2;

                double area = Math.Sqrt(semiPerimeter * (semiPerimeter - aSide) * (semiPerimeter - bSide) * (semiPerimeter - cSide));
                area = Math.Round(area, 2);
                return area;
            }
        }

        public Triangle() { }

        public Triangle(Point _firstPoint, Point _secondPoint, Point _thirdPoint)
        {
            point[0] = _firstPoint;
            point[1] = _secondPoint;
            point[2] = _thirdPoint;
        }

        public void Input()
        {
            Console.WriteLine("Enter the coordinats of {0} point(s)", numberOfPoints);
            for (int i = 0; i < numberOfPoints; i++)
            {
                Console.WriteLine("Point # {0}", i + 1);
                Console.Write("X:");

                string input = Console.ReadLine();
                if (Int32.TryParse(input, out point[i].x))
                    point[i].x = Int32.Parse(input);
                else
                    point[i].x = 0;
                
                Console.Write("Y:");
                input = Console.ReadLine();
                if (Int32.TryParse(input, out point[i].y))
                    point[i].y = Int32.Parse(input);
                else
                    point[i].y = 0;
            }
        }

        public void Output()
        {
            Console.WriteLine("Triangle");
            for (int i = 0; i < numberOfPoints; i++)
                Console.WriteLine("Point # {0} - {1}", i + 1, point[i]);

            Console.WriteLine("Perimeter: {0}", Perimeter);
            Console.WriteLine("Area: {0}", Area);
            Console.WriteLine();
        }

        public int CompareTo(object _object)
        {
            if (_object == null)
                return 1;

            IShape otherObject = _object as IShape;
            if (otherObject != null)
            {
                if (this.Area > otherObject.Area)
                    return 1;
                if (this.Area == otherObject.Area)
                    return 0;
                else
                    return -1;
            }
            else
            {
                throw new ArgumentException("Current Object has no shape");
            }
        }

        public Object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
