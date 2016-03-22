using SessionManagement.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SessionManagement.Hosting
{
    class Program
    {
        static void Main(string[] args)
        {
            using (ServiceHost host = new ServiceHost(typeof(SessionManagementService)))
            {
                host.Opened += delegate
                {
                    Console.WriteLine("The session management service has been started up!");
                };

                host.Open();

                Timer timer = new Timer(delegate { SessionManager.RenewSessions(); }, null, 0, 5000);

                Console.Read();

            }
        }
    }
}
