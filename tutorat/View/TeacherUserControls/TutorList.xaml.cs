using System.Windows;
using System.Windows.Controls;

namespace tutorat.View.TeacherUserControls
{
    public partial class TutorList : UserControl
    {
        public TutorList()
        {
            InitializeComponent();
        }

        private void ReturnDashboard_Click(object sender, RoutedEventArgs e)
        {
            // Ouvre la fenêtre TeacherDashboard
            var dashboard = new TeacherDashboard();
            dashboard.Show();

            // Ferme la fenêtre actuelle
            var currentWindow = Window.GetWindow(this);
            if (currentWindow != null)
                currentWindow.Close();
        }
    }
}
