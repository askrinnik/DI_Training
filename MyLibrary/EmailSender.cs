using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
