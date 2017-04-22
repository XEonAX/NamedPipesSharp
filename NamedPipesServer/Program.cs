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
            ServiceHost dynamicServiceHost = new ServiceHost(typeof(DynamicDataProcessor), new Uri("net.pipe://127.0.0.1/Dynamic" + endpoint));
            //A new instance of DynamicDataProcessor will be created for every client
            dynamicServiceHost.AddServiceEndpoint(typeof(IDataProcessor), new NetNamedPipeBinding(), "");
            dynamicServiceHost.Open();
            Console.WriteLine(dynamicServiceHost.BaseAddresses[0].ToString());


            var instance = new InstanciatedDataProcessor() { InstanceName = "NamedInstance" };
            ServiceHost instanciatedServiceHost = new ServiceHost(instance, new Uri("net.pipe://127.0.0.1/Instance"));
            //Only above "instance" will be used by all clients.
            instanciatedServiceHost.AddServiceEndpoint(typeof(IDataProcessor), new NetNamedPipeBinding(), "");
            instanciatedServiceHost.Open();
            Console.WriteLine(instanciatedServiceHost.BaseAddresses[0].ToString());


            Console.WriteLine("Press [ENTER] to exit.");
            Console.ReadLine();
            dynamicServiceHost.Close();
            instanciatedServiceHost.Close();
        }
    }
}
