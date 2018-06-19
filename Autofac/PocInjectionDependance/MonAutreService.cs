using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PocInjectionDependance
{
    class MonAutreService: IService, IAutreService
    {
        public string Message { get; internal set; }
        public void AfficherMessage()
        {
            Console.WriteLine($"MonAutreService: {Message}");
        }

        public void AfficherMessage(string message)
        {
            Console.WriteLine($"MonAutreService: {message}");
        }
    }
}
