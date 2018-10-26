using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace LiskovSubstitution
{
    class Rectangle
    {
        public virtual int Width { get; set; }
        public virtual int Height { get; set; }

        public Rectangle()
        {
        }

        public Rectangle(int width, int height)
        {
            Width = width;
            Height = height;
        }

        //RESHARPER (GENERATE FORMATTING MEMBERS)
        public override string ToString()
        {
            return $"{nameof(Width)}: {Width}, {nameof(Height)} : {Height}";
        }
    }

    class Square : Rectangle
    {
        public override int Width
        {
            set { base.Width = base.Height = value; }
        }

        public override int Height
        {
            set { base.Height = base.Width = value; }
        }
    }
    class Program
    {
        static public int Area(Rectangle r) => r.Width * r.Height;
        static void Main(string[] args)
        {
            Rectangle rc = new Rectangle(5, 25);
            WriteLine($"{rc} has area {Area(rc)}");

            Rectangle sq = new Square();
            sq.Width = 4;
            WriteLine($"{sq} has area {Area(sq)}");
        }
    }
}
