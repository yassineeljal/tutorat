using System.Windows;
using tutorat.Service.MeetingService;
using tutorat.ViewModel;

namespace tutorat.View
{

    public partial class Meeting : Window
    {
        private MeetingViewModel _viewModel;
        public Meeting()
        {
            InitializeComponent();
            _viewModel = new MeetingViewModel(new MeetingService());
            DataContext = _viewModel;
        }
    }
}
