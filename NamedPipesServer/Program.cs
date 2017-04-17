using NamedPipesSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;

namespace NamedPipesServer
{
    class Program
    {
        static void Main(string[] args)
        {
            Random rnd = new Random();
            string endpoint = "RandomizerPipe" + rnd.Next(10000);
            using (ServiceHost serviceHost = new ServiceHost(typeof(DataProcessor), new Uri("net.pipe://127.0.0.1/" + endpoint)))
            {
                serviceHost.AddServiceEndpoint(typeof(IDataProcessor), new NetNamedPipeBinding(), "");
                serviceHost.Open();
                Console.WriteLine(serviceHost.BaseAddresses[0].ToString());
                Console.WriteLine("Press [ENTER] to exit.");
                Console.ReadLine();
                serviceHost.Close();
            }
        }
    }
}
