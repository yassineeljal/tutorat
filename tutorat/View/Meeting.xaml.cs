using System.Windows;

namespace tutorat.View
{
    public partial class Meeting : Window
    {
        public Meeting()
        {
            InitializeComponent();
        }

        private void ReturnDashboard_Click(object sender, RoutedEventArgs e)
        {
            var dashboard = new TeacherDashboard();
            dashboard.Show();

            this.Close();
        }
    }
}
