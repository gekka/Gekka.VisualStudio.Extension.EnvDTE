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
    class Document : EnvDTE.IDocument
    {
        public Document(E.Document doc)
        {
            Reload(doc);
        }

        internal void Reload(E.Document doc)
        {
            this.Kind = doc.Kind;
            this.FullName = doc.FullName;
            this.Name = doc.Name;
            this.Path = doc.Path;
            this.ReadOnly = doc.ReadOnly;
            this.Saved = doc.Saved;
            this.IndentSize = doc.IndentSize;
            this.Language = doc.Language;
            this.TabSize = doc.TabSize;
            this.Type = doc.Type;
        }


        public string Kind {get;private set;}

        public string FullName {get;private set;}

        public string Name {get;private set;}

        public string Path {get;private set;}

        public bool ReadOnly {get;private set;}

        public bool Saved {get;private set;}

        public int IndentSize {get;private set;}

        public string Language {get;private set;}

        public int TabSize {get;private set;}

        public string Type {get;private set;}
    }

#pragma warning restore VSTHRD010
}
