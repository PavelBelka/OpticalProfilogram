using dissertation.Commands;
using System.Windows;
using System.Windows.Input;

namespace dissertation.ViewModels
{
    internal class MainWindowViewModel : BaseViewModel
    {
        private string _Text_log;

        /// <summary>Текст лога</summary>
        public string Text_log
        {
            get => _Text_log;
            set => Set(ref _Text_log, value);
        }

        public ICommand CloseApplicationCommand { get; }

        private bool CanCloseApplicationCommandExecute(object p) => true;
 

        private void OnCloseApplicationCommandExecute(object p) => Application.Current.Shutdown();

        public MainWindowViewModel()
        {
            CloseApplicationCommand = new ActionCommand(OnCloseApplicationCommandExecute, CanCloseApplicationCommandExecute);
            Text_log = "Тест лога";
        }
    }
}
