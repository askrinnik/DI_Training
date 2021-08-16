using System;
using MyApps.Interfaces;

namespace MyLibrary.MessageWriters
{
    public class ConsoleMessageWriter : IMessageWriter
    {
        public void Write(string message)
        {
            Console.WriteLine(message);
        }
    }
}
