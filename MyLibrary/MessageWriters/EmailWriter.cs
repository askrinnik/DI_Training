using System;
using MyApps.Interfaces;

namespace MyLibrary.MessageWriters
{
    public class EmailWriter : IMessageWriter
    {
        public void Write(string message)
        {
            Console.WriteLine($@"A email with message <{message}> was sent.");
        }
    }
}