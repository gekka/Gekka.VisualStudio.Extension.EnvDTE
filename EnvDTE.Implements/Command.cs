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

    class Command : ICommand
    {
        public Command(E.Command cmd)
        {
            Name = cmd.Name;
            Guid = cmd.Guid;
            ID = cmd.ID;
            IsAvailable = cmd.IsAvailable;
            LocalizedName = cmd.LocalizedName;
        }

        

        public string Name { get; }

        public string Guid { get; }

        public int ID { get; }

        public bool IsAvailable { get; }

        public string LocalizedName { get; }
    }
#pragma warning restore VSTHRD010
}
