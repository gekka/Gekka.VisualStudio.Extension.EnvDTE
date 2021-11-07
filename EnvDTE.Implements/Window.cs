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

    class Window : EnvDTE.IWindow
    {
        public Window(E.Window w)
        {
            this.HWnd = Tool.ToIntPtrFromHWnd(w.HWnd);
        }

        public IntPtr HWnd { get; }
    }

#pragma warning restore VSTHRD010
}
