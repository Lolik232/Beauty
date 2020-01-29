using Beauty.Core.Interfaces;
using Beauty.Data;
using Beauty.Data.Interfaces;
using Beauty.WPF.Interfaces;
using Beauty.WPF.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Beauty.WPF.Views
{
    /// <summary>
    /// Логика взаимодействия для LoginView.xaml
    /// </summary>
    public partial class LoginView : BaseView<LoginViewModel>, ICollectionable, ISecurable
    {
        public bool HasItems
        {
            get
            {
                return WorkersComboBox.HasItems;
            }
        }

        public SecureString SecurePassword
        {
            get
            {
                return PasswordBox.SecurePassword;
            }
        }

        public bool IsPasswordEmpty
        {
            get
            {
                return SecurePassword.Length.Equals(0);
            }
        }

        public LoginView()
        {
            InitializeComponent();
        }
    }
}
