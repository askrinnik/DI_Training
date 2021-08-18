using MyLibrary.MessageWriters;

namespace PureDI_ConsoleApp
{
    public class HelloWorldWithWriterApp
    {
        private readonly ConsoleMessageWriter _messageWriter = new ();
        public void SayHello()
        {
            _messageWriter.Write("Hello World!");
        }
    }
}
