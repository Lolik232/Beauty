using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Beauty.WPF.Controls
{
    public partial class IconButton : Button
    {
        public Geometry Icon
        {
            get => (Geometry)GetValue(IconProperty);
            set => SetValue(IconProperty, value);
        }
            
        public static readonly DependencyProperty IconProperty = DependencyProperty.Register(
            nameof(Icon),
            typeof(Geometry),
            typeof(IconButton),
            default
        );
            
        public IconButton()
        {
            InitializeComponent();
        }
    }
}
