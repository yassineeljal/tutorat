using System.Windows;
using tutorat.Service.AvailabilityService;
using tutorat.ViewModel;

namespace tutorat.View
{
    public partial class AvailabilityWindow : Window
    {
        private AvailabilityViewModel viewModel;
        public AvailabilityWindow()
        {
            InitializeComponent();
            viewModel = new AvailabilityViewModel(new AvailabilityService());
            DataContext = viewModel;
        }
    }
}
