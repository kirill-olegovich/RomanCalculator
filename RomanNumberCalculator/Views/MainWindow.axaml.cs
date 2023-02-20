using Avalonia.Controls;
using RomanNumberCalculator.ViewModels;

namespace RomanNumberCalculator.Views
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainWindowViewModel();
        }
    }
}
