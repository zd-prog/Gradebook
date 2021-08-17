using Gradebook.Models;
using Gradebook.ViewModels;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Unity;

namespace Gradebook
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            IUnityContainer container = new UnityContainer();
            Context context = new Context();
            Authorization authorizationWindow = new Authorization();
            container.RegisterInstance<IPasswordSupplier>(authorizationWindow);
            AuthorizationViewModel viewModel = new AuthorizationViewModel(context.students.ToList(), context.teachers.ToList(), container, context, authorizationWindow);
            authorizationWindow.DataContext = viewModel;
            authorizationWindow.Show();
        }
    }
}
