namespace Gekka.VisualStudio.Extension.EnvDTE
{
    public interface ICommands
    {
        IDTE Parent { get; }
        int Count { get; }
        ICommand Item(object index, int ID);
    }

}
