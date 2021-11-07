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

    [System.ComponentModel.Composition.Export(typeof(EnvDTE.IDTE))]
    class DTE : EnvDTE.IDTE
    {
        internal E.DTE dte { get; private set; }

        //public IntPtr? HWnd { get; private set; }

        public string Name => dte.Name;
        public string FileName => dte.FileName;
        public string Version => dte.Version;

        public IEvents Events => _Events ?? (_Events = new Events(this));
        private IEvents _Events;

        public IWindow MainWindow => _MainWindow ?? (_MainWindow = new Window(dte.MainWindow));
        private IWindow _MainWindow;

        public ICommands Commands => _Commands ?? (_Commands = new Commands(this));
        private ICommands _Commands;

        public string CommandLineArguments => dte.CommandLineArguments;
        public int LocaleID => dte.LocaleID;
        public string FullName => dte.FileName;
        public string Edition => dte.Edition;

        public bool Initialize(IServiceProvider serviceProvider)
        {
            dte = serviceProvider?.GetService(typeof(Microsoft.VisualStudio.Shell.Interop.SDTE)) as E.DTE;
            return dte != null;
        }

        ~DTE()
        {
        }
    }

#pragma warning restore VSTHRD010

}
