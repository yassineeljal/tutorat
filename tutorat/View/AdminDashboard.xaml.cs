using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using tutorat.Service.StudentService;
using tutorat.Service.TeacherService;
using tutorat.Service.TutorService;
using tutorat.ViewModel;

namespace tutorat.View
{
    /// <summary>
    /// Logique d'interaction pour AdminDashboard.xaml
    /// </summary>
    public partial class AdminDashboard : Window
    {
        private AdminDashboardViewModel viewModel;

        public AdminDashboard()
        {
            InitializeComponent();
            viewModel = new AdminDashboardViewModel(new StudentService(), new TutorService(), new TeacherService());
            DataContext = viewModel;
        }
    }
}
