using Beauty.WPF.Interfaces;
using Catel.Services;
using System.Security;
using System.Windows.Controls;

namespace Beauty.WPF.Views
{
    /// <summary>
    /// Логика взаимодействия для LoginView.xaml
    /// </summary>
    public partial class LoginView : BaseView, ICollectionable, ISecurable
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

            set
            {
                IsPasswordEmpty = value;
            }
        }

        public LoginView()
        {
            InitializeComponent();
        }
    }
}