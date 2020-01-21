using Beauty.Data;
using Beauty.Data.Interfaces;
using Beauty.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beauty.WPF.ViewModels
{
    public sealed class WorkerViewModel : BaseViewModel
    {
        private int id;
        private string fullname;
        private string positions;
        private string password;

        public int Id
        {
            get
            {
                return id;
            }

            set
            {
                id = value;
                OnPropertyChanged(nameof(Id));
            }
        }

        public string Fullname
        {
            get
            {
                return fullname;
            }

            set
            {
                fullname = value;
                OnPropertyChanged(nameof(Fullname));
            }
        }

        public string Positions
        {
            get
            {
                return positions;
            }

            set
            {
                positions = value;
                OnPropertyChanged(nameof(Positions));
            }
        }

        public string Password
        {
            get
            {
                return password;
            }

            set
            {
                password = value;
                OnPropertyChanged(nameof(Password));
            }
        }
    }
}
