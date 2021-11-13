using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gekka.VisualStudio.Extension.EnvDTE
{
    public interface IDocument
    {
        string Kind { get; }
        string FullName { get; }
        string Name { get; }
        string Path { get; }
        bool ReadOnly { get; }
        bool Saved { get; }
        int IndentSize { get; }
        string Language { get; }
        int TabSize { get; }
        string Type { get; }
    }
}
