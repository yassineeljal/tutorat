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
using tutorat.Service.RequestService;
using tutorat.Service.StudentService;
using tutorat.Service.TutorService;
using tutorat.ViewModel;

namespace tutorat.View
{
    /// <summary>
    /// Logique d'interaction pour LinkStudentTutor.xaml
    /// </summary>
    public partial class LinkStudentTutor : Window
    {
        private LinkStudentTutorViewModel _viewModel;
        public LinkStudentTutor()
        {
            InitializeComponent();
            _viewModel = new LinkStudentTutorViewModel(new TutorService(), new StudentService(), new RequestService());
            DataContext = _viewModel;
        }
    }
}
