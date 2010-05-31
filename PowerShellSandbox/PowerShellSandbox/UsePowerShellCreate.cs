using System;
using System.Collections.ObjectModel;
using System.Management.Automation;
using System.Management.Automation.Runspaces;
using System.Diagnostics;

namespace PowerShellSandbox
{
    class UsePowerShellCreate
    {
        public void Run()
        {
            System.Environment.CurrentDirectory = @"C:\";

            using (PowerShell shell = PowerShell.Create())
            {
                foreach (string str in shell.
                    AddCommand("get-location").
                    AddCommand("ls").
                    AddCommand("Out-String").       // Make the output of each command be included in the string.
                    Invoke<string>())
                {
                    Console.WriteLine(str);
                }
            }
            Console.WriteLine("Done with command");
            Console.ReadKey();
        }
    }
}
