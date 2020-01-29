using Beauty.WPF.Enums;
using Beauty.WPF.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Threading.Tasks;
using System.Windows.Controls;
using Beauty.WPF.Extensions;
using Beauty.WPF.Infrastructure;
using Beauty.WPF.ViewModels;

namespace Beauty.WPF.Views
{
    public class BaseView : Page, IView
    {
        private object viewModelObject;

        public ViewAnimations ViewLoadAnimation { get; set; }
        public ViewAnimations ViewUnloadAnimation { get; set; }
        public float AnimationTime { get; set; }

        public bool ShouldAnimateOut { get; set; }

        public object ViewModelObject
        {
            get
            {
                return viewModelObject;
            }

            set
            {
                if (Equals(viewModelObject, value))
                {
                    return;
                }

                viewModelObject = value;
                DataContext = viewModelObject;
            }
        }

        public BaseView()
        {
            ViewLoadAnimation = ViewAnimations.SlideAndFadeInFromRight;
            ViewUnloadAnimation = ViewAnimations.SlideAndFadeOutToLeft;
            AnimationTime = 0.8f;

            if (ViewLoadAnimation != ViewAnimations.None)
            {
                Visibility = Visibility.Collapsed;
            }

            Loaded += ViewLoaded;
        }

        private async void ViewLoaded(object sender, RoutedEventArgs e)
        {
            if (ShouldAnimateOut)
            {
                await AnimateOutAsync();
            }
            else
            {
                await AnimateInAsync();
            }
        }

        public async Task AnimateInAsync()
        {
            if (ViewLoadAnimation.Equals(ViewAnimations.SlideAndFadeInFromRight))
            {
                await this.SlideAndFadeInFromRight(AnimationTime);
            }
        }

        public async Task AnimateOutAsync()
        {
            if (ViewUnloadAnimation.Equals(ViewAnimations.SlideAndFadeOutToLeft))
            {
                await this.SlideAndFadeOutToLeft(AnimationTime);
            }
        }
    }

    public class BaseView<TViewModel> : BaseView where TViewModel : IViewModel, new()
    {
        public TViewModel ViewModel
        {
            get
            {
                return (TViewModel)ViewModelObject;
            }

            set
            {
                ViewModelObject = value;
            }
        }

        public BaseView()
            : base()
        {
            ViewModel = new TViewModel();
        }
    }
}
