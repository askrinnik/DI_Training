using System.Collections.Generic;

namespace MyLibrary.Applications
{
    public class HelloWorldWithManyWritersApp
    {
        private readonly IEnumerable<IMessageWriter> _writers;

        public HelloWorldWithManyWritersApp(IEnumerable<IMessageWriter> writers)
        {
            _writers = writers;
        }

        public void SayHello()
        {
            foreach (var writer in _writers)
                writer.Write("Hello World!");

        }
    }
}
