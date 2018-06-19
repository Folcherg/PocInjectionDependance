using Autofac;
using System;

namespace PocInjectionDependance
{
    class Program
    {
        private static IContainer Container { get; set; }
        static void Main(string[] args)
        {
            ContainerBuilder containerBuilder = new ContainerBuilder();
            containerBuilder.RegisterType<MonService>().As<IService>().As<IAutreService>();

            Container = containerBuilder.Build();

            using (ILifetimeScope scope = Container.BeginLifetimeScope())
            {
                IService service = scope.Resolve<IService>();
                service.AfficherMessage("Hello World");

                IAutreService otherservice = scope.Resolve<IAutreService>();
                otherservice.AfficherMessage();
            }
            
            Console.WriteLine("Press Key for Finish...");
            Console.ReadKey();
        }
    }
}
