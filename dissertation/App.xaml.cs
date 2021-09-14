using System.Windows;
using dissertation.ViewModels;
using dissertation.Models;

namespace dissertation
{
    public partial class App : Application
    {
        private void OnStartup(object sender, StartupEventArgs e)
        {
            MainWindow view = new MainWindow();
            Camera camera = new Camera();
            MainWindowViewModel viewModel = new MainWindowViewModel(camera);
            view.DataContext = viewModel;
            view.Show();
        }
    }
}
