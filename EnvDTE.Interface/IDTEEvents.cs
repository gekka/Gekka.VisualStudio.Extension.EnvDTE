using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gekka.VisualStudio.Extension.EnvDTE
{
    public interface IDTEEvents
    {
        event EventHandler<EventArgs> OnBeginShutdown;
    }
}
