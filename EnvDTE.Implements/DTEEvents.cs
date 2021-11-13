using EnvDTE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using E = global::EnvDTE;

namespace Gekka.VisualStudio.Extension.EnvDTE.Implements
{
#pragma warning disable VSTHRD010


    internal class DTEEvents : EnvDTE.IDTEEvents
    {
        internal DTEEvents(Events evs)
        {
            this._Parent = (DTE)evs.Parent;

            dev = evs.events.DTEEvents;
            dev.OnBeginShutdown += dev_OnBeginShutdown;
        }



        public IDTE Parent => _Parent;
        DTE _Parent;

        private E.DTEEvents dev;

        public event EventHandler<EventArgs> OnBeginShutdown;

        private void dev_OnBeginShutdown()
        {
            OnBeginShutdown?.Invoke(this, EventArgs.Empty);
        }
    }
#pragma warning restore VSTHRD010
}
