using System.Windows;
using System.Windows.Controls;

namespace tutorat.View
{
    public partial class StudentDashboard : Window
    {
        public StudentDashboard()
        {
            InitializeComponent();
        }

        private void OnOpenHelpRequest(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new StudentRequest());
        }

        private void OnOpenAvailability(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new CreateDisponibility());
        }
        private void OnLogoutClick(object sender, RoutedEventArgs e)
        {
            var loginWindow = new Login();
            loginWindow.Show();
            this.Close();
        }

    }
}
