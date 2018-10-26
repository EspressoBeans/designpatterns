using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenClosed2
{
    class Program
    {
        static void Main(string[] args)
        {
        }
    }

    //OLD WAY OF DEFINING SHAPE, WHERE EACH ONE IS DEFINED BY ITSELF
    public class Rectangle_old
    {
        public double Width { get; set; }
        public double Height { get; set; }
    }

    public class Circle_old
    {
        public double Radius { get; set; }
    }


    //NEW WAY OF DEFINING SHAPE WHERE WE TAKE ADVANTAGE OF INHERITANCE
    public abstract class Shape
    {
        public abstract double Area();
    }

    public class Rectangle : Shape
    {
        public double Width { get; set; }
        public double Height { get; set; }
        public override double Area()
        {
            return Width * Height;
        }
    }

    public class Circle : Shape
    {
        public double Radius { get; set; }
        public override double Area()
        {
            return Radius * Radius * Math.PI;
        }
    }





    public class AreaCalculator
    {
        //ORIGINAL OLD CODE, ONLY RECTANGLES
        public double Area(Rectangle_old[] shapes)
        {
            double area = 0;
            foreach (var shape in shapes)
            {
                area += shape.Width * shape.Height;
            }

            return area;
        }

        //NOW TO ACCOMODATE RECTANGLES AND CIRCLES
        public double Area(object[] shapes)
        {
            double area = 0;
            foreach (var shape in shapes)
            {
                if (shape is Rectangle_old)
                {
                    Rectangle_old rectangle = (Rectangle_old)shape;  //convert object to rectangle
                    area += rectangle.Width * rectangle.Height;
                }

                if (shape is Circle_old)
                {
                    Circle_old circle = (Circle_old)shape; //convert object to circle
                    area += circle.Radius * circle.Radius * Math.PI;
                }
            }

            return area;
        }

        //NOW WITH USING THE OPEN-CLOSE PRINCIPLE.
        public double Area(Shape[] shapes)
        {
            double area = 0;
            foreach (var shape in shapes)
            {
                area += shape.Area();
            }

            return area;
        }
    }
}
