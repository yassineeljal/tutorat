using System.Windows.Controls;
using tutorat.Service.MeetingService;
using tutorat.ViewModel;

namespace tutorat.View
{
    public partial class Meeting : Page
    {
        public Meeting(MeetingViewModel vm)
        {
            InitializeComponent();
            DataContext = vm;
        }
    }
}
