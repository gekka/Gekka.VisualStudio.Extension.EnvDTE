namespace Gekka.VisualStudio.Extension.EnvDTE
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.ComponentModel.Composition;
    using System.ComponentModel.Composition.Hosting;

    public class Tool
    {
        public static readonly string SUBDIR_X86 = "X86";
        public static readonly string SUBDIR_X64 = "X64";

        public static IDTE Load(IServiceProvider serviceProvider)
        {
            var thisAsm = System.Reflection.Assembly.GetExecutingAssembly();
            var dir = System.IO.Path.GetDirectoryName(thisAsm.Location);
            return Load(serviceProvider, dir);
        }
        public static IDTE Load(IServiceProvider serviceProvider, string baseDir)
        {
            string dir = System.IO.Path.Combine(baseDir, IntPtr.Size == 4 ? SUBDIR_X86 : SUBDIR_X64);

            var cat = new DirectoryCatalog(dir);
            var container = new CompositionContainer(cat);

            var idtes = container.GetExportedValues<IDTE>();

            var idte = idtes.FirstOrDefault();
            if (idte == null)
            {
                return null;
            }
            if (serviceProvider != null)
            {
                idte.Initialize(serviceProvider);
            }
            return idte;
        }

        //public static IntPtr ToIntPtrFromDTE(object dte)
        //{
        //    //dynamic d = dte;
        //    //object obj;
        //    try
        //    {
        //        var mw = dte.GetType().GetProperty("MainWindow").GetValue(dte);
        //        var obj=mw.GetType().GetProperty("HWnd").GetValue(mw);
        //        //obj = d.MainWindow.HWnd;
        //        return ToIntPtrFromHWnd(obj);
        //    }
        //    catch
        //    {
        //        return null;
        //    }
        //}

        public static IntPtr ToIntPtrFromHWnd(object hwnd)
        {
            if (hwnd is IntPtr ip)
            {
                return ip;
            }
            else if (hwnd is UIntPtr uip)
            {
                if (IntPtr.Size == 4)
                {
                    return new IntPtr(unchecked((int)uip.ToUInt32()));
                }
                else if (IntPtr.Size == 8)
                {
                    return new IntPtr(unchecked((long)uip.ToUInt64()));
                }
            }
            else if (hwnd is IConvertible ic)
            {
                if (IntPtr.Size == 4)
                {
                    return new IntPtr(ic.ToInt32(null));
                }
                else if (IntPtr.Size == 8)
                {
                    return new IntPtr(ic.ToInt64(null));
                }
            }

            return IntPtr.Zero;
        }
    }
}
