using System.Windows;

namespace tutorat.View
{
    public partial class TutorDashboard : Window
    {
        public TutorDashboard()
        {
            InitializeComponent();
        }



        private void OnOpenCreateMeeting(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new CreateMeeting());
        }

        private void OnOpenAvailability(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new CreateDisponibility()); 
        }
    }
}
