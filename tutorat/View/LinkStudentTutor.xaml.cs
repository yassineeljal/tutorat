using System.Windows.Controls;
using tutorat.Service.RequestService;
using tutorat.Service.StudentService;
using tutorat.Service.TutorService;
using tutorat.ViewModel;

namespace tutorat.View
{
    public partial class LinkStudentTutor : Page
    {
        private readonly LinkStudentTutorViewModel _viewModel;

        public LinkStudentTutor()
        {
            InitializeComponent();
            _viewModel = new LinkStudentTutorViewModel(
                new TutorService(),
                new StudentService(),
                new RequestService()
            );
            DataContext = _viewModel;
        }
    }
}
