using System;
using MyApps.Interfaces;

namespace MyLibrary.MessageWriters
{
    public class DatabaseWriter : IMessageWriter
    {
        public void Write(string message)
        {
            Console.WriteLine($@"A message <{message}> was sent to the database.");
        }
    }
}