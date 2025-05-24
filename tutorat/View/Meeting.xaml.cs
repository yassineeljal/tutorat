using System.Windows;
using tutorat.Service.MeetingService;
using tutorat.ViewModel;

namespace tutorat.View
{
    public partial class Meeting : Window
    {

        private MeetingViewModel viewModel;
        public Meeting()
        {
            InitializeComponent();

            viewModel  = new MeetingViewModel(new MeetingService());
            DataContext = viewModel;

        }


        private void ReturnDashboard_Click(object sender, RoutedEventArgs e)
        {
            var teacherDashboard = new TeacherDashboard(); // Ouvre le tableau de bord enseignant
            teacherDashboard.Show(); // Affiche la nouvelle fenêtre
            this.Close(); // Ferme la fenêtre actuelle
        }

    }
}
