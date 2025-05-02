using System.Windows;
using tutorat.ViewModel;

namespace tutorat.View
{
    public partial class AvailabilityWindow : Window
    {
        public AvailabilityWindow()
        {
            InitializeComponent();
            DataContext = new AvailabilityViewModel();
        }
    }
}
