using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Beauty.WPF.Controls
{
    public partial class RemovableItemsControl : ItemsControl
    {
        public ICommand Command
        {
            get => (ICommand)GetValue(CommandProperty);
            set => SetValue(CommandProperty, value);
        }

        public static readonly DependencyProperty CommandProperty = DependencyProperty.Register(
            nameof(Command),
            typeof(ICommand),
            typeof(RemovableItemsControl),
            default
        );

        public RemovableItemsControl()
        {
            InitializeComponent();
        }
    }
}
