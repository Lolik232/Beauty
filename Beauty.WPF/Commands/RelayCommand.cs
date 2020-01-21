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

        public RelayCommand(Action execute, bool canExecute = true)
        {
            this.execute = execute;
            this.canExecute = canExecute;
        }

        public override bool CanExecute(object parameter = null)
        {
            return canExecute;
        }

        public override void Execute(object parameter = null)
        {
            execute();
        }
    }
}
