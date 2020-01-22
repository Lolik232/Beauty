using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Beauty.WPF.Commands
{
    public class RelayCommand : BaseCommand
    {
        private Action execute;
        private bool canExecute;
        private Predicate<object> predicateCanExecute;

        public RelayCommand(Action execute, bool canExecute = true)
        {
            this.execute = execute;
            this.canExecute = canExecute;
        }

        public RelayCommand(Action execute, Predicate<object> canExecute = null)
        {
            this.execute = execute;
            this.predicateCanExecute = canExecute;
        }

        public override bool CanExecute(object parameter = null)
        {
            return canExecute || (predicateCanExecute is null || predicateCanExecute(parameter));
        }

        public override void Execute(object parameter = null)
        {
            execute();
        }
    }
}
