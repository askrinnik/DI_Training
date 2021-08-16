using System;
using MyApps.Interfaces;

namespace MyLibrary.MessageWriterDecorators
{
    public class RedConsoleMessageWriter : IMessageWriter
    {
        private readonly IMessageWriter _writer;

        public RedConsoleMessageWriter(IMessageWriter writer)
        {
            _writer = writer;
        }
        public void Write(string message)
        {
            var color = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Red;
            _writer.Write(message);
            Console.ForegroundColor = color;

        }
    }
}