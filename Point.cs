using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proga
{
    public struct Point
    {
        public int x;
        public int y;

        public Point(int _x, int _y)
        {
            this.x = _x;
            this.y = _y;
        }

        public override string ToString()
        {
            return "X:" + x + " Y:" + y;
        }

        public double Distance(Point _point)
        {
            double distance;
            distance = Math.Sqrt(Math.Pow((this.x - _point.x), 2) + Math.Pow((this.y - _point.y), 2));
            return distance;
        }
    }
}
