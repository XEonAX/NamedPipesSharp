using NamedPipesSharp;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.ServiceModel;
using System.Text;

namespace NamedPipesClient
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Paste endpoint address like: 'net.pipe://127.0.0.1/RandomizerPipe1234' to connect to.");
            string endpoint = Console.ReadLine();
            ChannelFactory<IDataProcessor> dataProcessorFactory = new ChannelFactory<IDataProcessor>(new NetNamedPipeBinding(), 
                                        new EndpointAddress(endpoint));
            IDataProcessor dataProceesorProxy =
              dataProcessorFactory.CreateChannel();

            while (true)
            {
                Console.WriteLine("Press [Enter] to process;");
                Console.ReadLine();

                Stopwatch s = new Stopwatch();
                s.Start();
                Console.WriteLine("It took " + dataProceesorProxy.Process() + " attempts to get rnd.Next(0, 10000000) == 500000.");
                s.Stop();
                Console.WriteLine("Last Throw took " + s.ElapsedMilliseconds + "ms.");
            }
        }
    }
}
