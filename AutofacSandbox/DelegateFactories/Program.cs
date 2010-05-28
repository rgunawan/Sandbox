using Autofac.Builder;

namespace DelegateFactories
{
    class Program
    {
        static void Main()
        {
            var container = BuildContainer();

            var blog = container.Resolve<Interfaces.IBlog>(
                new Autofac.NamedParameter("title", "Doug's blog"),
                new Autofac.NamedParameter("description", "A blog about nothing"));

            var newPost = blog.AddPost("Day 1", "Doug Mulley", "This is my first post, on the first day");
            newPost.AddComment("Kari Mulley", "Boring");

            System.Console.WriteLine(blog.ToString());

            System.Console.WriteLine();
            System.Console.WriteLine("Press any key to exit...");
            System.Console.ReadKey();
        }

        private static Autofac.IContainer BuildContainer()
        {
            var builder = new Autofac.Builder.ContainerBuilder();

            builder.Register<Factory.IComment>(delegate(string author, string content)
            {
                return new Comment(author, content);
            });

            builder.Register<Factory.IPosting>(ctx => delegate(string title, string author, string content)
            {
                return new Posting(title, author, content, ctx.Resolve<Factory.IComment>());
            });

            builder.Register<Factory.IBlog>(ctx =>
                delegate(string title, string description)
                {
                    return new Blog(title, description, ctx.Resolve<Factory.IPosting>());
                });

            builder.Register(typeof(Blog)).As<Interfaces.IBlog>();

            return builder.Build();
        }
    }
}
