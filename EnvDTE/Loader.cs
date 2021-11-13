
namespace Gekka.VisualStudio.Extension.EnvDTE
{
    using System;
    using System.ComponentModel.Composition.Hosting;
    using System.Linq;


    public static class Loader
    {
        public static readonly string SUBDIR_X86 = "X86";
        public static readonly string SUBDIR_X64 = "X64";

        public static IDTE Load(IServiceProvider svp)
        {
            var thisAsm = System.Reflection.Assembly.GetExecutingAssembly();
            try
            {
                var dir = System.IO.Path.GetDirectoryName(thisAsm.Location);
                dir = System.IO.Path.Combine(dir, IntPtr.Size == 4 ? SUBDIR_X86 : SUBDIR_X64);
                var cat = new DirectoryCatalog(dir);
                var parts = cat.Parts.ToList();

                var container = new CompositionContainer(cat);
                var idtes = container.GetExportedValues<IDTE>();
                IDTE idte = idtes.FirstOrDefault();
                if (idte == null)
                {
                    return null;
                }

                idte.Initialize(svp);

                return idte;
            }
            catch
            {
                return null;
            }
        }
    }
}
