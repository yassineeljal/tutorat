using System.Windows.Controls;
using tutorat.Service.MeetingService;
using tutorat.ViewModel;

namespace tutorat.View
{
    public partial class Meeting : Page
    {
        private MeetingViewModel MeetingViewModel;
        public Meeting(MeetingViewModel vm)
        {
            InitializeComponent();
            MeetingViewModel = vm;
            DataContext = vm;
        }
    }
}
