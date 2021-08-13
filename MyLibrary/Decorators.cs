using System;
using System.Collections.Generic;

namespace MyLibrary
{
    public class MessageCapitalizer : IMessageWriter
    {
        private readonly IMessageWriter _writer;

        public MessageCapitalizer(IMessageWriter writer)
        {
            _writer = writer;
        }

        public void Write(string message)
        {
            _writer.Write(message.ToUpperInvariant());
        }
    }

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

    public class WritersComposer : IMessageWriter
    {
        private readonly IEnumerable<IMessageWriter> _writers;

        public WritersComposer(IEnumerable<IMessageWriter> writers)
        {
            _writers = writers;
        }

        public void Write(string message)
        {
            foreach (var writer in _writers) 
                writer.Write(message);
        }
    }

}
