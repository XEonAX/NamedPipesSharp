using NamedPipesSharp;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace NamedPipesServer
{
    public class DynamicDataProcessor : IDataProcessor
    {
        public string InstanceName { get; set; }
        public DynamicDataProcessor()
        {
            InstanceName = Guid.NewGuid().ToString();
        }
        public DataMessage Process(DataMessage message)
        {
            Console.WriteLine("Processing on instance: " + InstanceName);
            Stopwatch s = new Stopwatch();
            s.Start();
            Random rnd = new Random();
            int i = 0;
            while (rnd.Next(0, 10000000) != 500000)
                i++;

            message.Throws = i;
            message.ServerTime = s.ElapsedMilliseconds;
            s.Stop();
            Console.WriteLine("Last Throw took " + s.ElapsedMilliseconds + "ms.");
            return message;
        }
    }
}
