using MyApps.Interfaces;

namespace MyLibrary.MessageWriters
{
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