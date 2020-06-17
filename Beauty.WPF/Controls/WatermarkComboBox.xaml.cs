using System.Windows;
using System.Windows.Controls;

namespace Beauty.WPF.Controls
{
    public partial class WatermarkComboBox : ComboBox
    {
        public string Watermark
        {
            get => (string)GetValue(WatermarkProperty);
            set => SetValue(WatermarkProperty, value);
        }

        public static readonly DependencyProperty WatermarkProperty = DependencyProperty.Register(
            nameof(Watermark),
            typeof(string),
            typeof(WatermarkComboBox),
            default
        );

        public WatermarkComboBox()
        {
            InitializeComponent();
        }
    }
}
