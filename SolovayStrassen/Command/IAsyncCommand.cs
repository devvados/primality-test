using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SolovayStrassen.Command
{
    interface IAsyncCommand : ICommand
    {
        Task ExecuteAsync(object parameter);
    }
}
