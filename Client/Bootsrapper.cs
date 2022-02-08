using Caliburn.Micro;
using Client.ViewModels;
using System.Windows;

namespace Client
{
    public class Bootsrapper:BootstrapperBase
    {
        public Bootsrapper()
        {
            Initialize();
        }
        protected override void OnStartup(object sender, StartupEventArgs e)
        {
            DisplayRootViewFor<PalindromeClientWindowViewModel>();
        }
    }
}
