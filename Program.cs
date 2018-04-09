using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proga
{
    class Program
    {
        private List<IComparable> figure = new List<IComparable>();
        
        public void Input()
        {
            string input;
            while(true)
            {
                Console.WriteLine("Enter 's' for Square, 't' for Triangle, 'e' for ending inputing");
                input = Console.ReadLine().ToLower();
                if (input == "s")
                {
                    Square square = new Square();
                    square.Input();
                    figure.Add(square);
                }
                if (input == "t")
                {
                    Triangle triangle = new Triangle();
                    triangle.Input();
                    figure.Add(triangle);
                }
                if (input == "e")
                    break;
            }
        }

        private void Sort()
        {
            for (int i = 1; i < figure.Count; i++) 
            {
                for (int j = 0; j < figure.Count - i; j++)
                {
                    if (figure[j].CompareTo(figure[j + 1]) == 1)
                    {
                        ICloneable obj = figure[j] as ICloneable;
                        figure[j] = figure[j + 1];
                        figure[j + 1] = obj.Clone() as IComparable;
                    }
                }
            }
        }

        private void BetweenValues(int _aValue, int _bValue)
        {
            for (int i = 0; i < figure.Count; i++)
            {
                IShape currentObject = figure[i] as IShape;
                if(currentObject.Perimeter >= _aValue && currentObject.Perimeter <= _bValue)
                {
                    IInputOutput outputObject = currentObject as IInputOutput;
                    outputObject.Output();
                }
            }
        }

        public void Print()
        {
            if(figure.Count != 0)
            {
                foreach(IComparable obj in figure)
                {
                    IInputOutput outputObject = obj as IInputOutput;
                    outputObject.Output();
                }
            }
        }

        static void Main(string[] args)
        {
            Program program = new Program();
            program.Input();
            program.Sort();
            program.Print();
            Console.ReadKey();
        }
    }
}
