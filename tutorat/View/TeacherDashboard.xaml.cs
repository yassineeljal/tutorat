using System.Windows;
using System.Windows.Controls;
using tutorat.ViewModel;
using tutorat.Service.MeetingService;
using tutorat.Service.StudentService;
using tutorat.Service.TutorService;
using tutorat.Service.RequestService;

namespace tutorat.View
{
    public partial class TeacherDashboard : Window
    {
        public TeacherDashboard()
        {
            InitializeComponent();
        }

        private void ViewMeetings_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new Meeting(new MeetingViewModel(new MeetingService())
            ));
        }

        private void ConsultRequest_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new StudentDemandListWindow(
            
            ));
        }

        private void ConsultListTutors_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new TutorListWindow(           ));
        }

        private void OpenLinkStudentTutor_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new LinkStudentTutor());
           
        }
    }
}
