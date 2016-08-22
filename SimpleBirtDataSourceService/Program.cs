using SimpleBirtDataSource;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace SimpleBirtDataSourceService
{
    static class Program
    {
        static void Main()
        {
            if (!Properties.Settings.Default.AsConsole)
            {
                ServiceBase[] ServicesToRun;
                ServicesToRun = new ServiceBase[]
                {
                new DataSourceService()
                };
                ServiceBase.Run(ServicesToRun);
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Starting self-hosted WCF Service...");

                ServiceHost svcHostService = null;
                try
                {
                    svcHostService = new ServiceHost(typeof(DataSourceServer));
                    svcHostService.Open();
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("\n\nService DataSourceServer is Running  at following address: {0}", svcHostService.BaseAddresses[0].AbsoluteUri.ToString());
                }
                catch (Exception eX)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    svcHostService = null;
                    Console.WriteLine("Service can not be started \n\nError Message [" + eX.Message + "]" + eX.StackTrace);
                }
                if (svcHostService != null)
                {
                    Console.ResetColor();
                    Console.WriteLine("\nPress any key to close the Service");
                    Console.ReadKey();
                    svcHostService.Close();
                    svcHostService = null;
                }
                else
                {
                    Console.ReadKey();
                }

            }
        }
    }
}
