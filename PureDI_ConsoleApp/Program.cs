using System;
using MyLibrary;
using MyLibrary.Applications;
using MyLibrary.Applications.BankOperationReader;

namespace PureDI_ConsoleApp
{
    class Program
    {
        static void Main()
        {
            //SimpleHelloWorldApp_Example();
            //HelloWorldWithWriter_Example();
            //HelloWorldWithDecorator1_Example();
            //HelloWorldWithDecorator2_Example();
            //HelloWorldWithManyWriters_Example();
            //HelloWorldWithComposer_Example();
            //HelloWorldWithAdapter_Example();
            //BankApp_Example();
            //BankAppWithCache_Example();
            BankOperationReaderApp_Example();

            Console.ReadLine();
        }

        private static void SimpleHelloWorldApp_Example()
        {
            var app = new SimpleHelloWorldApp();
            app.SayHello();
        }

        private static void HelloWorldWithWriter_Example()
        {
            var writer = new ConsoleMessageWriter();
            var app = new HelloWorldApp(writer);
            app.SayHello();
        }

        private static void HelloWorldWithDecorator1_Example()
        {
            var app = new HelloWorldApp(
                new MessageCapitalizer(
                    new ConsoleMessageWriter()));
            app.SayHello();
        }

        private static void HelloWorldWithDecorator2_Example()
        {
            var app = new HelloWorldApp(
                new RedConsoleMessageWriter(
                    new MessageCapitalizer(
                        new ConsoleMessageWriter())));
            app.SayHello();
        }

        private static void HelloWorldWithManyWriters_Example()
        {
            var writers = new IMessageWriter[] { new ConsoleMessageWriter(), new EmailWriter(), new DatabaseWriter() };
            var app = new HelloWorldWithManyWritersApp(writers);
            app.SayHello();
        }

        private static void HelloWorldWithComposer_Example()
        {
            var writers = new IMessageWriter[] { new ConsoleMessageWriter(), new EmailWriter(), new DatabaseWriter() };
            var composer = new WritersComposer(writers);
            var app = new HelloWorldApp(composer);
            app.SayHello();
        }

        private static void HelloWorldWithAdapter_Example()
        {
            var app = new HelloWorldApp(
                new EmailSenderAdapter(
                    new EmailSender()));
            app.SayHello();
        }

        private static void BankApp_Example()
        {
            var app = new BankApp(
                new BankRepository(), 
                new ConsoleMessageWriter());
            app.Run();
        }

        private static void BankAppWithCache_Example()
        {
            var app = new BankApp(
                new CachedRepository(new BankRepository()), 
                new ConsoleMessageWriter());
            app.Run();
        }

        private static void BankOperationReaderApp_Example()
        {
            var repository = new CachedRepository(new BankRepository());
            var writer = new ConsoleMessageWriter();
            var handlers = new IHandler[]
            {
                new ReadAmountHandler(repository),
                new DisplayAmountHandler(writer),
                new TotalAmountAmountCalculatorHandler(writer)
            };
            var app = new BankOperationReaderApp(handlers);

            app.Process(new BankOperationRequest("Petrenko", "Sokolenko"));
            app.Process(new BankOperationRequest("Petrenko", "Shevchenko"));
            app.Process(new BankOperationRequest("Sokolenko", "Shevchenko"));
        }
    }
}
