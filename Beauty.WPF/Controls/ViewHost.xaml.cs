using Beauty.WPF.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Beauty.WPF.Controls
{
    /// <summary>
    /// Логика взаимодействия для ViewHost.xaml
    /// </summary>
    public partial class ViewHost : UserControl
    {
        public IView CurrentView
        {
            get
            {
                return (IView)GetValue(CurrentViewProperty);
            }

            set
            {
                SetValue(CurrentViewProperty, value);
            }
        }

        public static readonly UIPropertyMetadata MetadataProperty = new UIPropertyMetadata(CurrentPagePropertyChanged);

        public static readonly DependencyProperty CurrentViewProperty = DependencyProperty.Register(
            nameof(CurrentView), 
            typeof(IView), 
            typeof(ViewHost), 
            MetadataProperty
        );

        public ViewHost()
        {
            InitializeComponent();
        }

        private static void CurrentPagePropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var previousViewFrame = (d as ViewHost).PreviousView;
            var nextViewFrame = (d as ViewHost).NextView;

            var previousViewContent = nextViewFrame.Content;

            nextViewFrame.Content = null;

            previousViewFrame.Content = previousViewContent;

            if (previousViewContent is IView previousView)
            {
                previousView.ShouldAnimateOut = true;
            }

            nextViewFrame.Content = e.NewValue;
        }
    }
}
