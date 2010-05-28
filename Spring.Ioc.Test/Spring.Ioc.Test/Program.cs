using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Spring.Context;
using Spring.Objects.Factory.Support;

namespace Spring.Ioc.Test
{
    using Context.Support;

    class Program
    {
        static void Main(string[] args)
        {
            IApplicationContext applicationContext = ContextRegistry.GetContext();
            WriteObjects(applicationContext);

            applicationContext = GetProgrammaticallySetupContext();
            WriteObjects(applicationContext);

            Console.ReadKey();
        }

        private static void WriteObjects(IApplicationContext applicationContext)
        {
            Console.WriteLine("AppContext: " + applicationContext.Name);

            var myRepo = (Repository)applicationContext.GetObject("Repository1");

            Console.WriteLine("Repository1:");
            Console.WriteLine(myRepo.ToString());

            var myConn = (CifsConnection)applicationContext.GetObject("CifsLocation1");

            Console.WriteLine("myRepo.ConnectionInfo == myConn? " + (myRepo.ConnectionInfo == myConn));


            var myConn2 = (CifsConnection)applicationContext.GetObject("cifsLocation2");

            Console.WriteLine("cifsLocation2:");
            Console.WriteLine(myConn2.ToString());
        }

        static IApplicationContext GetProgrammaticallySetupContext()
        {
            var ctx = new GenericApplicationContext { Name = "Programmatical app context" };

            IObjectDefinitionFactory objectDefinitionFactory = new DefaultObjectDefinitionFactory();

            BuildCifsLocation1(objectDefinitionFactory, ctx);
            BuildRepository1(objectDefinitionFactory, ctx);
            BuildCifsFactory(objectDefinitionFactory, ctx);
            BuildCifsLocation2(objectDefinitionFactory, ctx);

            return ctx;
        }

        private static void BuildCifsLocation1(IObjectDefinitionFactory objectDefinitionFactory, GenericApplicationContext ctx)
        {
            var builder = ObjectDefinitionBuilder.RootObjectDefinition(objectDefinitionFactory, typeof(CifsConnection));
            builder.AddPropertyValue("Username", "CifsLocation1 programmatical username");

            ctx.RegisterObjectDefinition("CifsLocation1", builder.ObjectDefinition);
        }

        private static void BuildRepository1(IObjectDefinitionFactory objectDefinitionFactory, GenericApplicationContext ctx)
        {
            var builder = ObjectDefinitionBuilder.RootObjectDefinition(objectDefinitionFactory, typeof(Repository));
            builder.AddPropertyValue("Name", "Repository1 programmatical");
            builder.AddPropertyReference("ConnectionInfo", "CifsLocation1");

            ctx.RegisterObjectDefinition("Repository1", builder.ObjectDefinition);
        }

        private static void BuildCifsFactory(IObjectDefinitionFactory objectDefinitionFactory, GenericApplicationContext ctx)
        {
            var builder = ObjectDefinitionBuilder.RootObjectDefinition(objectDefinitionFactory, typeof(ConnectionFactory));

            ctx.RegisterObjectDefinition("cifsFactory", builder.ObjectDefinition);
        }

        private static void BuildCifsLocation2(IObjectDefinitionFactory objectDefinitionFactory, GenericApplicationContext ctx)
        {
            var builder = ObjectDefinitionBuilder.RootObjectDefinition(objectDefinitionFactory, typeof(CifsConnection));
            builder.SetFactoryObject("cifsFactory", "CreateCifsLocation");

            ctx.RegisterObjectDefinition("cifsLocation2", builder.ObjectDefinition);
        }
    }
}
