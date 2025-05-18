using System.Windows.Controls;
using tutorat.Service.MeetingService;
using tutorat.Service.StudentService;
using tutorat.Service.TutorService;
using tutorat.ViewModel;

namespace tutorat.View
{
    public partial class CreateMeeting : Page
    {
        private CreateMeetingViewModel _viewModel;

        public CreateMeeting()
        {
            InitializeComponent();
            _viewModel = new CreateMeetingViewModel(
                new TutorService(),
                new StudentService(),
                new MeetingService()
            );
            DataContext = _viewModel;
        }
    }
}
