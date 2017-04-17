using NamedPipesSharp;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace NamedPipesServer
{
    public class DataProcessor : IDataProcessor
    {
        public int Process()
        {
            Stopwatch s = new Stopwatch();
            s.Start();
            Random rnd = new Random();
            int i = 0;
            while (rnd.Next(0, 10000000) != 500000)
                i++;

            s.Stop();
            Console.WriteLine("Last Throw took " + s.ElapsedMilliseconds + "ms.");
            return i;
        }
    }
}
