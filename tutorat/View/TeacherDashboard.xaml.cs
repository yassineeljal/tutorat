using System.Windows;

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
            var meetingWindow = new Meeting();
            this.Close();
            meetingWindow.Show();
        }

        private void ConsultRequest_Click(object sender, RoutedEventArgs e)
        {
            var tutorListWindow = new TutorListWindow();
            this.Close();
            tutorListWindow.Show();
        }
    }
}
