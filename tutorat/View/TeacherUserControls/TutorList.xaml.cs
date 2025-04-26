using System.Windows.Controls;
using tutorat.Service.StudentService;
using tutorat.Service.TutorService;
using tutorat.ViewModel;

namespace tutorat.View.TeacherUserControls
{

    public partial class TutorList : UserControl
    {
        private TutorListViewModel _viewModel;

        public TutorList()
        {
            InitializeComponent();
            _viewModel = new TutorListViewModel(new TutorService(),new StudentService());
            DataContext = _viewModel;

        }
    }
}
