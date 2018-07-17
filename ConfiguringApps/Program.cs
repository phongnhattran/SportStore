﻿using System.IO;
using Microsoft.AspNetCore.Hosting;

namespace ConfiguringApps
{
    public class Program
    {
        public static void Main(string[] args)
        {
            BuildWebHost(args).Run();
        }

        public static IWebHost BuildWebHost(string[] args)
        {
            return new WebHostBuilder().UseKestrel().UseContentRoot(Directory.GetCurrentDirectory()).
                    UseIISIntegration().UseStartup<Startup>().Build();

                        
        }
    }
}
