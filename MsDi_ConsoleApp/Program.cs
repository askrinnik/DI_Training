using System;
using System.Linq;
using Microsoft.Extensions.DependencyInjection;
using MyLibrary;
using MyLibrary.Applications;
using MyLibrary.Applications.BankOperationReader;

namespace MsDi_ConsoleApp
{
    class Program
    {
        static void Main()
        {
            //HelloWorldWithWriter_Example();
            //HelloWorldWithDecorator1_Example();
            //HelloWorldWithManyWriters_Example();
            //HelloWorldWithAdapter_Example();
            //BankOperationReaderApp_Example();
            BankOperationReaderApp_Example2();

            Console.ReadLine();
        }
        private static void HelloWorldWithWriter_Example()
        {
            var services = new ServiceCollection();

            services.AddTransient<IMessageWriter, ConsoleMessageWriter>();
            services.AddTransient<HelloWorldApp>();
            var container = services.BuildServiceProvider(true);

            var app = container.GetRequiredService<HelloWorldApp>();
            app.SayHello();
        }

        private static void HelloWorldWithDecorator1_Example()
        {
            var services = new ServiceCollection();

            services.AddTransient<IMessageWriter>(c => 
                ActivatorUtilities.CreateInstance<MessageCapitalizer>(c, 
                    ActivatorUtilities.CreateInstance<ConsoleMessageWriter>(c)));
            services.AddTransient<HelloWorldApp>();
            var container = services.BuildServiceProvider(true);

            var app = container.GetRequiredService<HelloWorldApp>();
            app.SayHello();
        }

        private static void HelloWorldWithManyWriters_Example()
        {
            var services = new ServiceCollection();

            services.AddTransient<IMessageWriter, ConsoleMessageWriter>();
            services.AddTransient<IMessageWriter, EmailWriter>();
            services.AddTransient<IMessageWriter, DatabaseWriter>();
            services.AddTransient<HelloWorldWithManyWritersApp>();
            var container = services.BuildServiceProvider(true);

            var app = container.GetRequiredService<HelloWorldWithManyWritersApp>();
            app.SayHello();
        }

        private static void HelloWorldWithAdapter_Example()
        {
            var services = new ServiceCollection();

            services.AddTransient<EmailSender>();
            services.AddTransient<IMessageWriter, EmailSenderAdapter>();
            services.AddTransient<HelloWorldApp>();
            var container = services.BuildServiceProvider(true);

            var app = container.GetRequiredService<HelloWorldApp>();
            app.SayHello();
        }

        private static void BankOperationReaderApp_Example()
        {
            var services = new ServiceCollection();

            services.AddTransient<IRepository>(c =>
                ActivatorUtilities.CreateInstance<CachedRepository>(c,
                    ActivatorUtilities.CreateInstance<BankRepository>(c)));
            services.AddTransient<IMessageWriter, ConsoleMessageWriter>();
            services.AddTransient<IHandler, ReadAmountHandler>();
            services.AddTransient<IHandler, DisplayAmountHandler>();
            services.AddTransient<IHandler, TotalAmountAmountCalculatorHandler>();
            services.AddTransient<BankOperationReaderApp>();
            var container = services.BuildServiceProvider(true);

            var app = container.GetRequiredService<BankOperationReaderApp>();
            app.Process(new BankOperationRequest("Petrenko", "Sokolenko"));
            app.Process(new BankOperationRequest("Petrenko", "Shevchenko"));
            app.Process(new BankOperationRequest("Sokolenko", "Shevchenko"));
        }

        private static void BankOperationReaderApp_Example2()
        {
            var services = new ServiceCollection();

            services.AddTransient<IRepository>(c =>
                ActivatorUtilities.CreateInstance<CachedRepository>(c,
                    ActivatorUtilities.CreateInstance<BankRepository>(c)));
            services.AddTransient<IMessageWriter, ConsoleMessageWriter>();

            var types = typeof(IHandler).Assembly.GetTypes()
                .Where(type => !type.IsAbstract && typeof(IHandler).IsAssignableFrom(type))
                .ToArray();
            foreach (var type in types) 
                services.AddTransient(type);
            foreach (var type in types)
                services.AddTransient(c => (IHandler)c.GetRequiredService(type));

            services.AddTransient<BankOperationReaderApp>();
            var container = services.BuildServiceProvider(true);

            var app = container.GetRequiredService<BankOperationReaderApp>();
            app.Process(new BankOperationRequest("Petrenko", "Sokolenko"));
            app.Process(new BankOperationRequest("Petrenko", "Shevchenko"));
            app.Process(new BankOperationRequest("Sokolenko", "Shevchenko"));
        }

    }
}
