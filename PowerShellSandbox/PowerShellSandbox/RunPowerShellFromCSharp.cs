using System;
using System.Collections.ObjectModel;
using System.Management.Automation;
using System.Management.Automation.Runspaces;
using System.Diagnostics;

namespace PowerShellSandbox
{
    class RunPowerShellFromCSharp
    {
        public void Run()
        {
            var getRepositoryCommand = new Command("get-repository");
            var sortCommand = new Command("Sort-Object");
            sortCommand.Parameters.Add("Property", "VM");

            RunspaceConfiguration rc = RunspaceConfiguration.Create();
            
            PSSnapInException snapEx = null;

            PSSnapInInfo info= rc.AddPSSnapIn("vRanger.API.PowerShell",out snapEx);
            
            using (Runspace runSpace = RunspaceFactory.CreateRunspace(rc))
            {
                
                runSpace.Open();    
                Pipeline pipeline = runSpace.CreatePipeline();
                pipeline.Commands.Add("cd");
                pipeline.Commands[0].Parameters.Add("Path", @"D:\Projects\vRangerTrunk\bin\Debug");
                pipeline.Commands.Add("get-location");
                //pipeline.Commands.Add(getRepositoryCommand);
                //pipeline.Commands.Add("ls");
                
                //pipeline.Commands.Add(sortCommand);
                //pipeline.Commands.Add("Out-String");
                Collection<PSObject> output = null;
                try
                {
                    output = pipeline.Invoke();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("error:" + ex.Message);
                }
                if (output != null)
                {
                    foreach (PSObject psObject in output)
                    {
                        //var process = (Process)psObject.BaseObject;
                        Console.WriteLine(psObject.ToString());
                    }
                }
                runSpace.Close();
            }
            Console.WriteLine("Done with command");
            Console.ReadKey();
        }
    }
}
