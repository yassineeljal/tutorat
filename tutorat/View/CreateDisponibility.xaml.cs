using System.Windows.Controls;
using tutorat.Service.AvailabilityService;
using tutorat.Service.StudentService;
using tutorat.Service.TutorService;
using tutorat.ViewModel;

namespace tutorat.View
{

    public partial class CreateDisponibility : Page
    {
        private CreateDisponibilityViewModel viewModel;

        public CreateDisponibility()
        {
            InitializeComponent();
            viewModel = new CreateDisponibilityViewModel(
                new AvailabilityService(),
                new TutorService(),
                new StudentService()
            );
            DataContext = viewModel;
        }
    }
}
