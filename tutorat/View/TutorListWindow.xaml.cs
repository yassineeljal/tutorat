using System.Windows.Controls;
using tutorat.Service.TutorService;
using tutorat.ViewModel;

namespace tutorat.View
{
    public partial class TutorListWindow : Page
    {
        private readonly TutorListViewModel _viewModel;

        public TutorListWindow()
        {
            InitializeComponent();
            _viewModel = new TutorListViewModel(new TutorService());
            DataContext = _viewModel;
        }
    }
}
