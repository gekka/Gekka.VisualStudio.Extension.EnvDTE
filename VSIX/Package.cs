namespace Gekka.VisualStudio.Extension.EnvDTE.Test
{
    using Microsoft.VisualStudio.Shell;
    using System;
    using System.Threading;
    using Task = System.Threading.Tasks.Task;
    using System.ComponentModel.Composition;
    using System.ComponentModel.Composition.Hosting;
    using System.Linq;
    using Gekka.VisualStudio.Extension.EnvDTE;

    [ProvideAutoLoad(EnvDTE80.ContextGuids.vsContextGuidNoSolution, PackageAutoLoadFlags.BackgroundLoad)]
    [ProvideAutoLoad(EnvDTE80.ContextGuids.vsContextGuidSolutionExists, PackageAutoLoadFlags.BackgroundLoad)]
    [PackageRegistration(UseManagedResourcesOnly = true, AllowsBackgroundLoading = true)]
    [System.Runtime.InteropServices.Guid(Package.PackageGuidString)]
    public sealed class Package : AsyncPackage
    {
        public const string PackageGuidString = "bf1d5e11-0914-4f12-8ce7-b50db31c8493";

        private EnvDTE.IDTE idte;

        #region Package Members

        public Package()
        {

        }
        protected override async Task InitializeAsync(CancellationToken cancellationToken, IProgress<ServiceProgressData> progress)
        {
            await this.JoinableTaskFactory.SwitchToMainThreadAsync(cancellationToken);

            try
            {
                idte = Loader.Load(this);
                idte.Events.CommandEvents.BeforeExecute += commandEvents_BeforeExecute;
            }
            catch
            {

            }
        }

        private void commandEvents_BeforeExecute(object sender, EnvDTE.CommandEventsArgs e)
        {

        }

        #endregion
    }
}
