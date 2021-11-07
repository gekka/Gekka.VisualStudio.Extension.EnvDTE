namespace Gekka.VisualStudio.Extension.EnvDTE
{
    public interface IEvents
    {
        IDTE Parent { get; }
        ICommandEvents CommandEvents { get; }
    }

}
