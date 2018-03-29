using SolovayStrassen.ViewModels;
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;

namespace SolovayStrassen
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        public MainWindow()
        {
            DataContext = new MainWindowViewModel();
            InitializeComponent();
        }

        /// <summary>
        /// MetroDialog
        /// </summary>
        /// <param name="text"></param>
        /// <param name="title"></param>
        public async void ShowMessageBox(string text, string title)
        {
            MetroDialogSettings ms = new MetroDialogSettings()
            {
                ColorScheme = MetroDialogColorScheme.Theme,
                AnimateShow = true,
                AnimateHide = true,
                DialogMessageFontSize = 12,
                DialogTitleFontSize = 24,
            };
            await this.ShowMessageAsync(title, text, MessageDialogStyle.Affirmative, ms);
        }

        private void BAbout_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            ShowMessageBox("Checking the integer for primality by a Solovay-Strassen test" +
                "\nStudent of M8O-112M,\nDmitriev Vadim", "Info");
        }
    }
}
