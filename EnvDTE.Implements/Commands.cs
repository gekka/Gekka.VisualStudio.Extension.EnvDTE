using EnvDTE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EnvDTE = global::EnvDTE;

namespace Gekka.VisualStudio.Extension.EnvDTE.Implements
{
#pragma warning disable VSTHRD010

    class Commands : EnvDTE.ICommands
    {
        public Commands(DTE parent)
        {
            this._Parent = parent;
        }

        public IDTE Parent => _Parent;
        DTE _Parent;

        public int Count => _Parent.dte.Commands.Count;

        public ICommand Item(object index, int ID)
        {
            Command ret = null;
            var cmd = this._Parent.dte.Commands.Item(index, ID);
            if (cmd != null)
            {
                ret = new Command(cmd);
                if (cmd.GetType().IsCOMObject)
                {
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(cmd);
                }
            }
            return ret;
        }
    }
#pragma warning restore VSTHRD010
}
