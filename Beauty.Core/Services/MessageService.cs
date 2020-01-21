using Beauty.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Beauty.Core.Services
{
    public class MessageService : IMessageService
    {
        public void ShowMessage(string title, string message, MessageBoxImage icon)
        {
            MessageBox.Show(message, title, MessageBoxButton.OK, icon);
        }

        public void ShowInformation(string message)
        {
            ShowMessage("Информация", message, MessageBoxImage.Information);
        }

        public void ShowError(string message)
        {
            ShowMessage("Ошибка", message, MessageBoxImage.Error);
        }

        public void ShowExclamation(string message)
        {
            ShowMessage("Предупреждение", message, MessageBoxImage.Exclamation);
        }

        public void ShowQuestion(string title, string message)
        {
            ShowMessage(title, message, MessageBoxImage.Question);
        }
    }
}
