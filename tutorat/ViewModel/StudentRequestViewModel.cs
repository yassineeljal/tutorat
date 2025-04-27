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
        public ObservableCollection<String> Categories { get; set; } = new ObservableCollection<String>
        {
            "A",
            "B",
            "C",
        };
        private readonly IRequestService _requestService;
        private readonly IStudentService _studentService;

        public StudentRequestViewModel(IRequestService requestService, IStudentService studentService)
        {
            _requestService = requestService;
            _studentService = studentService;
            SelectedCategory = Categories.FirstOrDefault();

        }
        [ObservableProperty]
        private String selectedCategory;
        [ObservableProperty]
        private String subjectInput;
        [ObservableProperty]
        private String noteInput;
        [ObservableProperty]
        private String daInput;

        [RelayCommand]
        private void CreateRequest()
        {
            MessageBox.Show("CreateRequest invoquée");
            if (string.IsNullOrEmpty(subjectInput) || string.IsNullOrEmpty(selectedCategory) || string.IsNullOrEmpty(noteInput) || string.IsNullOrEmpty(daInput))
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
                Subject = subjectInput,
                Category = selectedCategory,
                Note = int.Parse(noteInput),
                Student = student
            };
            _requestService.CreateRequest(request);

        }





    }
}
