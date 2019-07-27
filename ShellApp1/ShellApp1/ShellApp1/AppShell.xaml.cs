using ShellApp1.Views;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace ShellApp1
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        private Dictionary<string, Type> routes = new Dictionary<string, Type>();

        public ICommand AboutCommand => new Command(async () =>
        {
            await Shell.Current.GoToAsync("about", true);
            Shell.Current.FlyoutIsPresented = false;  //retract flyout
        });

        public ICommand SettingsCommand => new Command(async () =>
        {
            // do something...
            await Task.Delay(1000);
            Shell.Current.FlyoutIsPresented = false;  //retract flyout
        });

        public AppShell()
        {
            InitializeComponent();
            RegisterRoutes();
            BindingContext = this;
        }

        private void RegisterRoutes()
        {
            routes.Add("about", typeof(AboutPage));

            foreach (var item in routes)
            {
                Routing.RegisterRoute(item.Key, item.Value);
            }
        }
    }
}
