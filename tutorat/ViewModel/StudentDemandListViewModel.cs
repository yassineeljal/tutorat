using System.Collections.ObjectModel;
using System.Windows;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using data.Model;
using tutorat.Service.StudentService;
using tutorat.Service.TutorService;

namespace tutorat.ViewModel
{
    public partial class StudentDemandListViewModel : ObservableObject
    {
        private readonly IStudentService _studentService;
        private readonly ITutorService _tutorService;
        public ObservableCollection<Student> Students { get; set; } = new ObservableCollection<Student>();
        public ObservableCollection<Student> StudentsSearch { get; set; } = new ObservableCollection<Student>();

        public StudentDemandListViewModel(IStudentService studentService, ITutorService tutorService)
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
            _studentService.Create(new Student
            {
                FirstName = "Mathilde",
                LastName = "Lemoine",
                Da = 123456
            });
            _studentService.Create(new Student
            {
                FirstName = "Julien",
                LastName = "Girard",
                Da = 654321
            });
            _tutorService.Create(new Tutor
            {
                FirstName = "Prof",
                LastName = "Test",
                Da = 777
            });
            var students = _studentService.GetAll();
            foreach (var student in students)
            {
                Students.Add(student);
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
            MessageBox.Show("fi");


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
                    Tutor tutor = new Tutor
                    {
                        FirstName = newStudent.FirstName,
                        LastName = newStudent.LastName,
                        Da = newStudent.Da,
                    };
                    _tutorService.Create(tutor);
                    MessageBox.Show("adwfgh");
                }

            }

        }
    }
}