using System.Collections.Generic;
using MyApps.Interfaces;

namespace MyApps
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
