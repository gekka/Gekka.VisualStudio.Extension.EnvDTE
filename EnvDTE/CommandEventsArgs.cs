namespace Gekka.VisualStudio.Extension.EnvDTE
{
    using System;

    public class CommandEventsArgs : EventArgs
    {
        public CommandEventsArgs(CommandEventType type, ICommand cmd)
        {
            this.EventType = type;
            this.Command = cmd;
            this.CancelDefault = CancelDefault;
        }

        public CommandEventType EventType { get; }

        public ICommand Command { get; }

        public bool CancelDefault { get; set; }

        public enum CommandEventType
        {
            Before,
            After
        }
    }



}
