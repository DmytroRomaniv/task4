using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proga
{
    public class Square: IShape, IInputOutput, IComparable, ICloneable
    {
        private const int numberOfPoints = 2;
        private Point[] point = new Point[numberOfPoints];

        public double Perimeter
        {
            get
            {
                double perimeter;
                perimeter = 2 * (Math.Abs(point[0].x - point[1].x) + Math.Abs(point[0].y - point[1].y));
                perimeter = Math.Round(perimeter, 2);
                return perimeter;
            }
        }

        public double Area
        {
            get
            {
                double area;
                area = Math.Abs(point[0].x - point[1].x) * Math.Abs(point[0].y - point[1].y);
                area = Math.Round(area, 2);
                return area;
            }
        }

        public Square() { }

        public Square(Point _firstPoint, Point _secondPoint)
        {
            point[0] = _firstPoint;
            point[1] = _secondPoint;
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
            Console.WriteLine("Square");
            for(int i=0;i<numberOfPoints;i++)
                Console.WriteLine("Point # {0} - {1}", i + 1, point[i]);

            Console.WriteLine("Perimeter: {0}", Perimeter);
            Console.WriteLine("Area: {0}", Area);
            Console.WriteLine();
        }

        
        public int CompareTo(object _object)
        {
            if(_object == null)
                return 1;

            IShape otherObject = _object as IShape;
            if(otherObject != null)
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
