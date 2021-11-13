namespace Gekka.VisualStudio.Extension.EnvDTE
{
    public interface ICommandEvents
    {
        event System.EventHandler<CommandEventsArgs> BeforeExecute;
        event System.EventHandler<CommandEventsArgs> AfterExecute;
    }
}
