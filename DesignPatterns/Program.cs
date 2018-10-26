using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace SingleResponsibility

{
    public class Journal
    {
        private readonly List<string> entries = new List<string>();
        private static int count = 0;

        public int AddEntry(string text)
        {
            entries.Add($"{++count}: {text}");
            return count; //mememto pattern
        }

        public void RemoveEntry(int index)
        {
            entries.RemoveAt(index);
        }

        public override string ToString()
        {
            return string.Join(Environment.NewLine, entries);
        }

        //THE BELOW ARE NOT GOOD PRACTICE AS THEY DO NOT ADHERE TO SINGLE RESPONSIBILITY PRINCIPLE
        //public void Save(string filename)
        //{
        //    File.WriteAllText(filename, ToString());
        //}

        //public static Journal Load(string filename)
        //{
        //    Journal j = new Journal();
        //    return j;
        //}

        //public void Load(Uri uri)
        //{

        //}

    }


    //This class allows for the Journal class to simply work with creating Journal entries.
    //In other words we don't want Journal.Save or Journal.Load methods.  Instead create another class that handles the saving and loading of the journal.
    public class Persistance
    {
        public void SaveToFile(Journal j, string filename, bool overwrite = false)
        {
            if (overwrite || !File.Exists(filename))
            {
                File.WriteAllText(filename, j.ToString());
            }
        }
    }
    class Demo
    {
        static void Main(string[] args)
        {
            var j = new Journal();
            j.AddEntry("I cried today");
            j.AddEntry("I ate a bug");
            WriteLine(j);

            var p = new Persistance();
            var filename = @"c:\tmp\journal.txt";
            p.SaveToFile(j, filename, true);
            Process.Start(filename);  //this brings file to foreground

        }


    }
}
