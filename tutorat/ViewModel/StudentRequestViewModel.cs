using System.Collections.ObjectModel;
using System.Windows;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using data.Model;
using tutorat.Service.RequestService;
using tutorat.Service.StudentService;

namespace tutorat.ViewModel
{
    public partial class StudentRequestViewModel : ObservableObject
    {
        public ObservableCollection<string> Categories { get; set; } = new ObservableCollection<string>
        {
            "IDO",
            "Interface humain machine",
            "Projet Web",
            "Application pour entreprise",
            "Infonuagique",
        };

        public ObservableCollection<string> Subjects { get; set; } = new ObservableCollection<string>
        {
            "Devenir tuteur",
            "Demander de l'aide"
        };



        private readonly IRequestService _requestService;
        private readonly IStudentService _studentService;

        public StudentRequestViewModel(IRequestService requestService, IStudentService studentService)
        {
            _requestService = requestService;
            _studentService = studentService;
            SelectedCategory = Categories.FirstOrDefault();
            SelectedSubject = Subjects.FirstOrDefault();

        }
        [ObservableProperty]
        private String selectedCategory;
        [ObservableProperty]
        private string selectedSubject;
        [ObservableProperty]
        private String noteInput;
        [ObservableProperty]
        private String daInput;

        [RelayCommand]
        private void CreateRequest()
        {
            if (string.IsNullOrEmpty(selectedSubject) || string.IsNullOrEmpty(selectedCategory) || string.IsNullOrEmpty(noteInput) || string.IsNullOrEmpty(daInput))
            {
                return;
                
            }
            var student = _studentService.GetByDa(int.Parse(daInput));
            if (student == null)
            {
                return;
            }
            var request = new Request
            {
                Subject = selectedSubject,
                Category = selectedCategory,
                Note = int.Parse(noteInput),
                StudentId = student.Id
            };
            _requestService.CreateRequest(request);
            MessageBox.Show("Demande envoyée");
        }
    }
}
