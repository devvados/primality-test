using SolovayStrassen.Algorithm;
using SolovayStrassen.Command;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace SolovayStrassen.ViewModels
{
    class MainWindowViewModel : INotifyPropertyChanged
    {
        public MainWindowViewModel()
        {
            SolvePrimality = AsyncCommand.Create(token => SSMethod.IsPrime(Number, Iterations, token));
        }

        private long _number;
        private int _iterations;

        public long Number
        {
            get => _number;
            set
            {
                _number = value;
                OnPropertyChanged();
                OnPropertyChanged("CanSolve");
            }
        }

        public int Iterations
        {
            get => _iterations;
            set
            {
                _iterations = value;
                OnPropertyChanged();
                OnPropertyChanged("CanSolve");
            }
        }

        public bool CanSolve
        {
            get => Iterations > 0 && Number > 0;
        }

        public IAsyncCommand SolvePrimality { get; private set; }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
