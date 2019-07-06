using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FileCounter
{
    internal class Program
    {
        private static IConfiguration Configuration { get; set; }
        private static IServiceProvider Provider { get; set; }
        private static IServiceCollection Services { get; set; }

        private static void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton(provider => Configuration);
            services.AddTransient<IReader, CsvFileReader>();
            services.AddTransient<ICounter, Counter>();
        }

        private static void Main(string[] args)
        {
            try
            {
                Configuration = ReadConfiguration();
            }
            catch (Exception exception)
            {
                Console.WriteLine("Unable to read configuration. " + exception.Message);
                Console.ReadKey();
            }

            Services = new ServiceCollection();
            ConfigureServices(Services);
            Provider = Services.BuildServiceProvider();

            try
            {
                List<File> files = Provider.GetRequiredService<ICounter>().Calculate();
                foreach (var file in files)
                {
                    Console.WriteLine(file.Type + " " + file.Count.ToString());
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }

            Console.ReadKey();
        }

        private static IConfiguration ReadConfiguration()
        {
            return new ConfigurationBuilder()
                .SetBasePath(Directory.GetParent(AppContext.BaseDirectory).FullName)
                .AddJsonFile("appsettings.json", false)
                .Build();
        }
    }
}
