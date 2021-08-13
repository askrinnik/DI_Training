using System;

namespace MyLibrary
{
    public interface IMessageWriter
    {
        void Write(string message);
    }

    public class ConsoleMessageWriter : IMessageWriter
    {
        public void Write(string message)
        {
            Console.WriteLine(message);
        }
    }

    public class EmailWriter : IMessageWriter
    {
        public void Write(string message)
        {
            Console.WriteLine($@"A email with message <{message}> was sent.");
        }
    }

    public class DatabaseWriter : IMessageWriter
    {
        public void Write(string message)
        {
            Console.WriteLine($@"A message <{message}> was sent to the database.");
        }
    }


    public class EmailSenderAdapter : IMessageWriter
    {
        private readonly EmailSender _sender;

        public EmailSenderAdapter(EmailSender sender)
        {
            _sender = sender;
        }

        public void Write(string message)
        {
            _sender.Send(message);
        }
    }


}
