using System.Windows.Controls;
using tutorat.Service.RequestService;
using tutorat.Service.StudentService;
using tutorat.ViewModel;

namespace tutorat.View
{
    public partial class StudentRequest : Page
    {
        private StudentRequestViewModel _viewModel;

        public StudentRequest()
        {
            InitializeComponent();
            _viewModel = new StudentRequestViewModel(new RequestService(), new StudentService());
            DataContext = _viewModel;
        }
    }
}
