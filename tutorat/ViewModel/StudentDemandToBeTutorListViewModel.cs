using System.Collections.ObjectModel;
using System.Windows;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using data.Model;
using tutorat.Service.StudentService;
using tutorat.Service.TutorService;

namespace tutorat.ViewModel
{
    public partial class StudentDemandToBeTutorListViewModel : ObservableObject
    {
        private readonly IStudentService _studentService;
        private readonly ITutorService _tutorService;
        public ObservableCollection<Student> Students { get; set; } = new ObservableCollection<Student>();
        public ObservableCollection<Student> StudentsSearch { get; set; } = new ObservableCollection<Student>();

        public StudentDemandToBeTutorListViewModel(IStudentService studentService, ITutorService tutorService)
        {
            _studentService = studentService;
            _tutorService = tutorService;
            LoadStudents();
        }

        [ObservableProperty]
        private string daInput;

        [ObservableProperty]
        private Student selectedStudent;

        [ObservableProperty]
        private string daInputCreateTutor;

        [ObservableProperty]
        [NotifyCanExecuteChangedFor(nameof(DeleteStudentCommand))]
        private Student selectedStudentSearch;

        private void LoadStudents()
        {
            var students = _studentService.GetAll();
            foreach (var student in students)
            {
                if(student.Requests == null)
                {
                    continue;
                }
                else
                {
                    foreach (var request in student.Requests)
                    {
                        if (request.Subject == "Devenir tuteur")
                        {
                            Students.Add(student);
                            break;
                        }
                        else
                        {
                            continue;
                        }
                    }
                }

            }
        }

        [RelayCommand]
        private void SearchStudent()
        {
            var student = _studentService.GetByDa(int.Parse(daInput));
            if (string.IsNullOrEmpty(daInput))
            {
                return;
            }
            if (student == null || StudentsSearch.FirstOrDefault(s => s.Da == student.Da) != null)
            {
                return;
            }
            else
            {
                StudentsSearch.Clear();
                StudentsSearch.Add(_studentService.GetByDa(int.Parse(daInput)));
            }
        }

        private bool canDeleteStudent()
        {
            return SelectedStudentSearch != null;
        }

        [RelayCommand(CanExecute = nameof(canDeleteStudent))]
        private void DeleteStudent()
        {
            if (SelectedStudentSearch != null)
            {
                _studentService.Delete(SelectedStudentSearch.Da);
                Students.Remove(SelectedStudentSearch);
                StudentsSearch.Clear();
                SelectedStudent = null;
            }
            else
            {
                return;
            }
        }

        [RelayCommand]
        private void CreateTutor()
        {

            if (string.IsNullOrEmpty(daInputCreateTutor))
            {
                return;
            }
            if (Students.FirstOrDefault(s => s.Da == int.Parse(daInputCreateTutor)) == null)
            {
                return;
            }
            else
            {
                var newStudent = _studentService.GetByDa(int.Parse(daInputCreateTutor));
                if (newStudent == null)
                {
                    return;
                }
                else
                {
                    var request = newStudent.Requests.FirstOrDefault(r => r.Subject == "Devenir tuteur");
                    Tutor tutor = new Tutor
                    {
                        FirstName = newStudent.FirstName,
                        LastName = newStudent.LastName,
                        Da = newStudent.Da,
                        Category = request.Subject,
                    };
                    _tutorService.Create(tutor);
                    MessageBox.Show("tuteur créé");
                }

            }

        }
    }
}