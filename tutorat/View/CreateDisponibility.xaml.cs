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
using tutorat.Service.AvailabilityService;
using tutorat.Service.StudentService;
using tutorat.Service.TutorService;
using tutorat.ViewModel;

namespace tutorat.View
{
    /// <summary>
    /// Logique d'interaction pour CreateDisponibility.xaml
    /// </summary>
    public partial class CreateDisponibility : Window
    {
        private CreateDisponibilityViewModel viewModel;
        public CreateDisponibility()
        {
            InitializeComponent();
            viewModel = new CreateDisponibilityViewModel(new AvailabilityService(), new TutorService(), new StudentService());
            DataContext = viewModel;
        }
    }
}
