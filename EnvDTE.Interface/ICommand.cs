namespace Gekka.VisualStudio.Extension.EnvDTE
{
    public interface ICommand
    {
        string Name { get; }
        string Guid { get; }
        int ID { get; }
        bool IsAvailable { get; }
        string LocalizedName { get; }
    }
}
