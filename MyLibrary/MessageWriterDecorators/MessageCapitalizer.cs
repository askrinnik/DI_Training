using MyApps.Interfaces;

namespace MyLibrary.MessageWriterDecorators
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
}