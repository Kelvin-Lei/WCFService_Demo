﻿using ContextPropagation.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace ContextPropagation.Hosting
{
    class Program
    {
        static void Main(string[] args)
        {
            using (ServiceHost host = new ServiceHost(typeof(Service)))
            {
                host.Opened += delegate
                {
                    Console.WriteLine("Service has been started up!");
                };

                host.Open();

                Console.Read();
            }
        }
    }
}
