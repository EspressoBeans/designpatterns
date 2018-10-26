using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using static System.Console;

namespace OpenClosed
{
    public enum Color
    {
        Red, Green, Blue
    }

    public enum Size
    {
        Small, Medium, Large, Huge
    }

    public class Product
    {
        public string Name;
        public Color Color;
        public Size Size;
        public Product(string name, Color color, Size size)
        {
            if (name == null)
            {
                throw new ArgumentNullException(paramName: nameof(name));
            }
            Name = name;
            Color = color;
            Size = size;
        }
    }

    //THIS PRODUCT FILTER SHOULD BE OPEN FOR EXTENSION BUT CLOSED FOR MODIFICATION.  THIS MEANS IT
    //SHOULD BE POSSIBLE TO MAKE NEW FILTERS, BUT NOBODY SHOULD BE GOING BACK INTO THE FILTER TO MAKE
    //MODIFICATIONS.
    public class ProductFilter
    {

        //OLD WAY #######################################
        //public IEnumerable<Product> FilterBySize(IEnumerable<Product> products, Size size)
        //{
        //    foreach (var p in products)
        //        if (p.Size == size)
        //            yield return p;
            
        //}

        //public IEnumerable<Product> FilterByColor(IEnumerable<Product> products, Color color)
        //{
        //    foreach (var p in products)
        //        if (p.Color == color)
        //            yield return p;
            
        //}

        //public IEnumerable<Product> FilterBySizeAndColor(IEnumerable<Product> products, Size size, Color color)
        //{
        //    foreach (var p in products)
        //        if (p.Size == size && p.Color == color)
        //            yield return p;

        //}





    }

    //NEW WAY ####################################################
    //THIS IS CALLED A SPECIFICATION PATTERN.  IT'S AN ENTERPRISE DESIGN PATTERN WHICH SPECIFIES WEATHER OR NOT SOMETHING MEETS A 
    //SPECIFIC CRITERIA.  IT IS A PREDICATE WHICH OPERATES ON ANY TYPE T
    public interface ISpecification<T>
    {
        bool IsSatisfied(T t);
    }



    public interface IFilter<T>
    {
        IEnumerable<T> Filter(IEnumerable<T> items, ISpecification<T> spec);
    }







    //CUSTOM SPECIFICATIONS USING AN INHERITABLE INTERFACE
    public class ColorSpecification : ISpecification<Product>

    {
        private Color color;
        public ColorSpecification(Color color)
        {
            this.color = color;
        }
        public bool IsSatisfied(Product t)
        {
            return t.Color == color;
        }
    }

    public class SizeSpecification : ISpecification<Product>
    {
        private Size size;

        public SizeSpecification(Size size)
        {
            this.size = size;
        }

        public bool IsSatisfied(Product t)
        {
            return t.Size == size;
        }

    }


    //A COMBINATOR SPECIFICATION
    public class AndSpecification<T> : ISpecification<T>
    {
        private ISpecification<T> first, second;

        public AndSpecification(ISpecification<T> first, ISpecification<T> second)
        {
            this.first = first ?? throw new ArgumentNullException(paramName: nameof(first));
            this.second = second ?? throw new ArgumentNullException(paramName: nameof(second));
        }


        public bool IsSatisfied(T t)
        {
            return first.IsSatisfied(t) && second.IsSatisfied(t);
        }
    }

    //FILTER WHICH USES
    public class BetterFilter : IFilter<Product>
    {
        public IEnumerable<Product> Filter(IEnumerable<Product> items, ISpecification<Product> spec)
        {
            foreach (var i in items)
            {
                if (spec.IsSatisfied(i))
                    yield return i;
            }
        }
    }


    public class Program
    {
        static void Main(string[] args)
        {
            var fender = new Product("Fender", Color.Green, Size.Small);
            var gibson = new Product("Gibson", Color.Blue, Size.Large);
            var martin = new Product("Martin", Color.Red, Size.Large);

            Product[] products = { fender, gibson, martin };

            //OLD WAY ######################################
            //var pf = new ProductFilter();
            //WriteLine("Green products (old):");
            //foreach (var p in pf.FilterByColor(products, Color.Green))
            //{
            //    WriteLine($" - {p.Name} is green");
            //}

            //NEW WAY #######################################
            var bf = new BetterFilter();
            WriteLine("Green products (new): ");
            foreach (var p in bf.Filter(products, new ColorSpecification(Color.Green)))
            {
                WriteLine($" - {p.Name} is green");
            }

            //NEW WAY WITH COMBINATOR SPECIFICATION ###############
            WriteLine("Large blue products (new): ");
            foreach (var p in bf.Filter(products, new AndSpecification<Product>(new ColorSpecification(Color.Blue), new SizeSpecification(Size.Large))))
            {
                WriteLine($" - {p.Name} is blue and large");
            }
        }
    }
}
