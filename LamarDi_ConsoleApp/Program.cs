using System;
using System.Linq;
using Lamar;
using Microsoft.Extensions.DependencyInjection;
using MyLibrary;
using MyLibrary.Applications;
using MyLibrary.Applications.BankOperationReader;

namespace LamarDi_ConsoleApp
{
    class Program
    {
        static void Main()
        {
            //HelloWorldWithWriter_Example();
            //HelloWorldWithDecorator1_Example();
            //HelloWorldWithManyWriters_Example();
            //HelloWorldWithAdapter_Example();
            BankOperationReaderApp_Example2();

            Console.ReadLine();
        }
        private static void HelloWorldWithWriter_Example()
        {
            var services = new ServiceRegistry();

            services.AddTransient<IMessageWriter, ConsoleMessageWriter>();
            services.AddTransient<HelloWorldApp>();
            var container = new Container(services);

            var app = container.GetRequiredService<HelloWorldApp>();
            app.SayHello();
        }

        private static void HelloWorldWithDecorator1_Example()
        {
            var services = new ServiceRegistry();

            services.AddTransient<IMessageWriter, ConsoleMessageWriter>();
            services.For<IMessageWriter>().DecorateAllWith<MessageCapitalizer>();
            services.AddTransient<HelloWorldApp>();
            var container = new Container(services);

            var app = container.GetRequiredService<HelloWorldApp>();
            app.SayHello();
        }

        private static void HelloWorldWithManyWriters_Example()
        {
            var services = new ServiceRegistry();

            services.AddTransient<IMessageWriter, ConsoleMessageWriter>();
            services.AddTransient<IMessageWriter, EmailWriter>();
            services.AddTransient<IMessageWriter, DatabaseWriter>();
            services.AddTransient<HelloWorldWithManyWritersApp>();
            var container = new Container(services);

            var app = container.GetRequiredService<HelloWorldWithManyWritersApp>();
            app.SayHello();
        }

        private static void HelloWorldWithAdapter_Example()
        {
            var services = new ServiceRegistry();

            services.AddTransient<EmailSender>();
            services.AddTransient<IMessageWriter, EmailSenderAdapter>();
            services.AddTransient<HelloWorldApp>();
            var container = new Container(services);

            var app = container.GetRequiredService<HelloWorldApp>();
            app.SayHello();
        }

        private static void BankOperationReaderApp_Example2()
        {
            var services = new ServiceRegistry();

            services.AddTransient<IRepository, BankRepository>();
            services.For<IRepository>().DecorateAllWith<CachedRepository>();
            services.AddTransient<IMessageWriter, ConsoleMessageWriter>();

            var types = typeof(IHandler).Assembly.GetTypes()
                .Where(type => !type.IsAbstract && typeof(IHandler).IsAssignableFrom(type))
                .ToArray();
            foreach (var type in types)
                services.For(typeof(IHandler)).Add(type);

            services.AddTransient<BankOperationReaderApp>();
            var container = new Container(services);

            var app = container.GetRequiredService<BankOperationReaderApp>();
            app.Process(new BankOperationRequest("Petrenko", "Sokolenko"));
            app.Process(new BankOperationRequest("Petrenko", "Shevchenko"));
            app.Process(new BankOperationRequest("Sokolenko", "Shevchenko"));
        }


    }
}
