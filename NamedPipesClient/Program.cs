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
                                        new EndpointAddress(endpoint));//Do not recreate everytime

            while (true)
            {
                Console.WriteLine("Press [Enter] to process;");
                Console.ReadLine();
                var msg = new DataMessage();
                Stopwatch s = new Stopwatch();
                s.Start();
                IDataProcessor dataProceesorProxy =  dataProcessorFactory.CreateChannel();//Can be recreated everytime when required
                var res = dataProceesorProxy.Process(msg);//Make rpc via ipc call.
                s.Stop();
                Console.WriteLine("It took " + res.Throws + " attempts to get rnd.Next(0, 10000000) == 500000.");
                Console.WriteLine("Last processing call took " + res.ServerTime + "ms on server");
                Console.WriteLine("Last processing call took " + (s.ElapsedMilliseconds - res.ServerTime) + "ms for data transfer");
            }
        }
    }
}
