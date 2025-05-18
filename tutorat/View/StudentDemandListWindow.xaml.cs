using System.Windows.Controls;
using tutorat.Service.StudentService;
using tutorat.Service.TutorService;
using tutorat.ViewModel;

namespace tutorat.View
{
    public partial class StudentDemandListWindow : Page
    {
        private readonly StudentDemandToBeTutorListViewModel _viewModel;

        public StudentDemandListWindow()
        {
            InitializeComponent();
            _viewModel = new StudentDemandToBeTutorListViewModel(
                new StudentService(),
                new TutorService()
            );
            DataContext = _viewModel;
        }
    }
}
