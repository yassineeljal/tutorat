using System.Windows;
using tutorat.Service.StudentService;
using tutorat.Service.TutorService;
using tutorat.ViewModel;

namespace tutorat.View
{
    public partial class TutorListWindow : Window
    {
        private TutorListViewModel _viewModel;

        public TutorListWindow()
        {
            InitializeComponent();
            _viewModel = new TutorListViewModel(new TutorService());
            DataContext = _viewModel;
        }

        private void ReturnDashboard_Click(object sender, RoutedEventArgs e)
        {
            var teacherDashboard = new TeacherDashboard(); // Ouvre le tableau de bord enseignant
            teacherDashboard.Show(); // Affiche la nouvelle fenêtre
            this.Close(); // Ferme la fenêtre actuelle
        }

    }

}
