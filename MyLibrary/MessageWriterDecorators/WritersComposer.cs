using System.Collections.Generic;
using MyApps.Interfaces;

namespace MyLibrary.MessageWriterDecorators
{
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
