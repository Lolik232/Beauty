using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Beauty.WPF.Commands
{
    public sealed class RelayCommand : BaseCommand
    {
        private Action execute;
        private Predicate<object> canExecute;

        public RelayCommand(Action execute, Predicate<object> canExecute = null)
        {
            this.execute = execute;
            this.canExecute = canExecute;
        }

        public override bool CanExecute(object parameter)
        {
            return canExecute is null || canExecute(parameter);
        }

        public override void Execute(object parameter)
        {
            execute();
        }
    }
}
