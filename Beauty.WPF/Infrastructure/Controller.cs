using Beauty.WPF.ViewModels;
using Catel.IoC;
using Catel.MVVM;
using Catel.MVVM.Views;
using System.Linq;

namespace Beauty.WPF.Infrastructure
{
    public static class Controller
    {
        public static ApplicationViewModel Application => Container.Get<ApplicationViewModel>();

        public static IView GetView<TView>(params object[] viewModelParameters)
        {
            if (viewModelParameters is null)
            {
                return Container.Get<TView>() as IView;
            }

            var viewModelLocator = Container.Get<IViewModelLocator>();
            var viewModelType = viewModelLocator.ResolveViewModel(typeof(TView));
            var viewModel = Container.GetWithParameters(viewModelType, viewModelParameters) as IViewModel;

            var view = Container.Get<TView>() as IView;

            return view;
        }
    }
}