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

    class Events : EnvDTE.IEvents
    {
        internal Events(DTE parent)
        {
            this._Parent = parent;

            this.events = parent.dte.Events;
        }

        public IDTE Parent => _Parent;
        DTE _Parent;

        internal E.Events events { get; }

        public ICommandEvents CommandEvents => _CommandEvents ?? (_CommandEvents = new CommandEvents(this));
        private CommandEvents _CommandEvents;
    }

#pragma warning restore VSTHRD010
}
