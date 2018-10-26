using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceSegregation
{

    public class Document
    {

    }

    public interface IMachine
    {
        void Print(Document document);
        void Scan(Document document);
        void Fax(Document document);
    }

    public class MultiFunctionPrinter : IMachine
    {
        public void Fax(Document document)
        {
            //
        }

        public void Print(Document document)
        {
            //
        }

        public void Scan(Document document)
        {
            // 
        }
    }

    public class OldFashionedPrinter : IMachine
    {
        public void Fax(Document document)
        {
            throw new NotImplementedException();
        }

        public void Print(Document document)
        {
            throw new NotImplementedException();
        }

        public void Scan(Document document)
        {
            throw new NotImplementedException();
        }
    }

    public interface IPrinter
    {
        void Print(Document document);
    }

    public interface IScan
    {
        void Scan(Document document);
    }

    interface IFax
    {
        void Fax(Document document);
    }

    public class Photocopier : IPrinter, IScan
    {
        public void Print(Document document)
        {
            throw new NotImplementedException();
        }

        public void Scan(Document document)
        {
            throw new NotImplementedException();
        }
    }

    public interface IMultiFunctionDevice : IScan, IPrinter
    {

    }

    public class MultiFunctionMachine : IMultiFunctionDevice
    {
        private IPrinter printer;
        private IScan scan;

        public MultiFunctionMachine(IPrinter printer, IScan scan)
        {
            this.printer = printer;
            this.scan = scan;
        }

        //this is the DECORATOR PATTERN for using interfaces.
        //i have implemented the interfaces but through a delegate.
        public void Print(Document document)
        {
            printer.Print(document);
        }

        public void Scan(Document document)
        {
            scan.Scan(document);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            
            MultiFunctionMachine mfm = new MultiFunctionMachine(,);
        }
    }
}
