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

    class CommandEvents : EnvDTE.ICommandEvents
    {
        internal CommandEvents(Events evs)
        {
            this._Parent = (DTE)evs.Parent;

            cev = evs.events.CommandEvents;
            cev.BeforeExecute += cev_BeforeExecute;
            cev.AfterExecute += cev_AfterExecute;
        }

        ~CommandEvents()
        {
            //cev.BeforeExecute -= cev_BeforeExecute;
            //cev.AfterExecute -= cev_AfterExecute;
        }

        public IDTE Parent => _Parent;
        DTE _Parent;

        private E.CommandEvents cev;

        public event EventHandler<CommandEventsArgs> BeforeExecute;
        public event EventHandler<CommandEventsArgs> AfterExecute;

        private void cev_AfterExecute(string Guid, int ID, object CustomIn, object CustomOut)
        {
            var cmd = this.Parent.Commands.Item(Guid, ID);
            var e = new CommandEventsArgs(CommandEventsArgs.CommandEventType.After, cmd);
            AfterExecute?.Invoke(this, e);
        }

        private void cev_BeforeExecute(string Guid, int ID, object CustomIn, object CustomOut, ref bool CancelDefault)
        {
            var cmd = this.Parent.Commands.Item(Guid, ID);
            var e = new CommandEventsArgs(CommandEventsArgs.CommandEventType.Before, cmd);
            BeforeExecute?.Invoke(this, e);
            CancelDefault = e.CancelDefault;
        }


    }

#pragma warning restore VSTHRD010
}
