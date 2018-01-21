using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WebService
{
    class Program
    {
        static void Main(string[] args)
        {
            String baseAddress = "http://localhost:8000/";
            Service service = null;
            if (args.Length>0) service = new Service() { FilePath= args[0] };
            else service = new Service() { FilePath = "" };
            ServiceHost host = new WebServiceHost(service, new Uri(baseAddress));
            var behavior = host.Description.Behaviors.Find<ServiceBehaviorAttribute>();
            behavior.InstanceContextMode = InstanceContextMode.Single;
            host.Open();

            Console.WriteLine("Service is running!");
            Thread.Sleep(Timeout.Infinite);
        }
    }
}
