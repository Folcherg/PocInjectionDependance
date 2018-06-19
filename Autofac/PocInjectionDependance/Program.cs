using Autofac;
using System;

namespace PocInjectionDependance
{
    class Program
    {
        private static IContainer Container { get; set; }
        static void Main(string[] args)
        {
            Step1();
            Step2();
            Step3();

            Console.WriteLine("Press Key for Finish...");
            Console.ReadKey();            
        }

        static void Step1()
        {
            Console.WriteLine("---- Step1 ----");
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
        }

        static void Step2()
        {
            Console.WriteLine("---- Step2 ----");
            ContainerBuilder containerBuilder = new ContainerBuilder();
            containerBuilder.Register(c =>
            {
                return new MonService() { Message = "Hello Parameter" };
            }).As<IService>().As<IAutreService>();

            Container = containerBuilder.Build();

            using (ILifetimeScope scope = Container.BeginLifetimeScope())
            {
                IService service = scope.Resolve<IService>();
                service.AfficherMessage("Hello World");

                IAutreService otherservice = scope.Resolve<IAutreService>();
                otherservice.AfficherMessage();
            }
        }

        static void Step3()
        {
            Console.WriteLine("---- Step3 ----");
            ContainerBuilder containerBuilder = new ContainerBuilder();
            containerBuilder.Register<IService>((c, p) =>
            {
                int serviceId = p.Named<int>("serviceId");
                if (serviceId == 0)
                {
                    return new MonService();
                }

                return new MonAutreService();
            }).As<IService>();

            Container = containerBuilder.Build();

            using (ILifetimeScope scope = Container.BeginLifetimeScope())
            {
                IService service1 = scope.Resolve<IService>(new NamedParameter("serviceId", 1));
                service1.AfficherMessage("Hello World");

                IService service2 = scope.Resolve<IService>(new NamedParameter("serviceId", 0));
                service2.AfficherMessage("Hello World");                
            }
        }
    }
}
