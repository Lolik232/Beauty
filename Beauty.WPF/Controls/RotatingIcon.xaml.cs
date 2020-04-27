using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Beauty.WPF.Controls
{
    public partial class RotatingIcon : UserControl
    {
        public Geometry Icon
        {
            get => (Geometry)GetValue(IconProperty);
            set => SetValue(IconProperty, value);
        }

        public static readonly DependencyProperty IconProperty = DependencyProperty.Register(
            nameof(Icon),
            typeof(Geometry),
            typeof(RotatingIcon),
            default
        );

        public RotatingIcon()
        {
            InitializeComponent();
        }
    }
}
