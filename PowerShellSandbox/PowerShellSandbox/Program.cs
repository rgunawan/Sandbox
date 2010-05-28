using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PowerShellSandbox
{
    class Program
    {
        static void Main(string[] args)
        {
            TestRunPowerShellFromCSharp();
        }

        private static void TestRunPowerShellFromCSharp()
        {
            var runner = new RunPowerShellFromCSharp();
            runner.Run();
        }
    }
}
