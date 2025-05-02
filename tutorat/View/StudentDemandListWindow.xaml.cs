using System.Windows;
using tutorat.Service.StudentService;
using tutorat.Service.TutorService;
using tutorat.ViewModel; // ⬅️ Assure-toi d’avoir bien ce using

namespace tutorat.View
{
    /// <summary>
    /// Logique d'interaction pour StudentDemandListWindow.xaml
    /// </summary>
    public partial class StudentDemandListWindow : Window
    {

        private StudentDemandListViewModel viewModel;
        public StudentDemandListWindow()
        {
            InitializeComponent();
            viewModel = new StudentDemandListViewModel(new StudentService(),new TutorService());
            DataContext = viewModel;
        }


        private void ReturnDashboard_Click(object sender, RoutedEventArgs e)
        {
            var teacherDashboard = new TeacherDashboard(); 
            teacherDashboard.Show();
            this.Close();
        }
    }
}






