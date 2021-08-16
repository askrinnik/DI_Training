using MyApps.Interfaces;

namespace MyApps
{
    public class HelloWorldApp
    {
        private readonly IMessageWriter _messageWriter;

        public HelloWorldApp(IMessageWriter messageWriter)
        {
            _messageWriter = messageWriter;
        }

        public void SayHello()
        {
            _messageWriter.Write("Hello World!");
        }
    }
}
