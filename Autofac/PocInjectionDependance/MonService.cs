using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PocInjectionDependance
{
    class MonService : IService, IAutreService
    {
        public void AfficherMessage(string message)
        {
            Console.WriteLine($"MonService: {message}");
        }

        public void AfficherMessage()
        {
            Console.WriteLine($"MonService: {Message}");
        }

        public string Message => "New Hello World!";
    }
}
