using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DelegateFactories
{
    class ConsoleLogger : Interfaces.ILogger 
    {
        public void Write(string message)
        {
            Console.WriteLine(string.Format("{0}|{1}", this.GetHashCode(), message));
        }
    }
}
