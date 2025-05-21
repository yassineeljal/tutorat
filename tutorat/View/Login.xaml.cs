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
    /// Logique d'interaction pour Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        private LoginViewModel _viewModel;
        public Login()
        {
            InitializeComponent();
            _viewModel = new LoginViewModel(new StudentService(), new TutorService(), new TeacherService());
            DataContext = _viewModel;
        }
        private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (this.DataContext is LoginViewModel vm)
            {
                vm.Password = ((PasswordBox)sender).Password;
            }
        }
    }
}
