using System;

namespace MyLibrary
{
    public class EmailSender
    {
        public void Send(string message)
        {
            Console.WriteLine($@"A email with message <{message}> was sent by EmailSender.");
        }
    }
}
