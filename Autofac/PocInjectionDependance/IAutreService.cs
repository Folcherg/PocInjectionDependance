using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PocInjectionDependance
{
    interface IAutreService
    {
        string Message { get; }
        void AfficherMessage();
    }
}
