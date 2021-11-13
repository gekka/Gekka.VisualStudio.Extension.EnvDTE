namespace Gekka.VisualStudio.Extension.EnvDTE
{
    public interface IDTE
    {
        bool Initialize(System.IServiceProvider serviceProvider);

        string Name { get; }
        string FileName { get; }
        string Version { get; }

        //Windows Windows { get; }

        IEvents Events { get; }

        //AddIns AddIns { get; }
        IWindow MainWindow { get; }
        //Window ActiveWindow { get; }
        //vsDisplay DisplayMode { get; }
        //Solution Solution { get; }
        ICommands Commands { get; }
        //Properties Properties { get; }
        //SelectedItems SelectedItems { get; }

        string CommandLineArguments { get; }

        //bool IsOpenFile { get; }
        //DTE DTE { get; }

        int LocaleID { get; }

        //WindowConfigurations WindowConfigurations { get; }
        //Documents Documents { get; }
        //Document ActiveDocument { get; }
        //Globals Globals { get; }
        //StatusBar StatusBar { get; }

        string FullName { get; }

        //bool UserControl { get; set; }
        //ObjectExtenders ObjectExtenders { get; }
        //Find Find { get; }
        //vsIDEMode Mode { get; }
        //ItemOperations ItemOperations { get; }
        //UndoContext UndoContext { get; }
        //Macros Macros { get; }
        //object ActiveSolutionProjects { get; }
        //DTE MacrosIDE { get; }
        //string RegistryRoot { get; }
        //DTE Application { get; }
        //ContextAttributes ContextAttributes
        //SourceControl SourceControl { get; }
        //bool SuppressUI { get; set; }
        //Debugger Debugger { get; }

        string Edition { get; }

        void ExecuteCommand(string commandName, string commandArgs = "");
        //IntPtr? HWnd { get; }

        IDocument ActiveDocument { get; }
    }
}
