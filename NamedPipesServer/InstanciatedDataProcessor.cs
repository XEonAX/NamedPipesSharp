using NamedPipesSharp;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.ServiceModel;
using System.Text;

namespace NamedPipesServer
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class InstanciatedDataProcessor : DynamicDataProcessor
    {
    }
}
