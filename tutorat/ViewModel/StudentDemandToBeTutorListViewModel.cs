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
            LoadStudentsAsync();
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

        private async Task LoadStudentsAsync()
        {
            try
            {
                var students = await _studentService.GetAllAsync();
                Students.Clear();

                foreach (var student in students)
                {
                    if (student.Requests == null) continue;

                    if (student.Requests.Any(r => r.Subject == "Devenir tuteur"))
                    {
                        Students.Add(student);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors du chargement des étudiants : {ex.Message}", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        [RelayCommand]
        private async Task SearchStudentAsync()
        {
            try
            {
                if (string.IsNullOrEmpty(daInput)) return;

                if (!int.TryParse(daInput, out var da)) return;

                var student = await _studentService.GetByDaAsync(da);

                if (student == null || StudentsSearch.Any(s => s.Da == student.Da)) return;

                StudentsSearch.Clear();
                StudentsSearch.Add(student);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors de la recherche de l'étudiant : {ex.Message}", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private bool CanDeleteStudent()
        {
            return SelectedStudentSearch != null;
        }

        [RelayCommand(CanExecute = nameof(CanDeleteStudent))]
        private async Task DeleteStudentAsync()
        {
            try
            {
                if (SelectedStudentSearch == null) return;

                await _studentService.DeleteAsync(SelectedStudentSearch.Da);
                Students.Remove(SelectedStudentSearch);
                StudentsSearch.Clear();
                SelectedStudent = null;

                MessageBox.Show("Étudiant supprimé avec succès.", "Succès", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors de la suppression de l'étudiant : {ex.Message}", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        [RelayCommand]
        private async Task CreateTutorAsync()
        {
            try
            {
                if (string.IsNullOrEmpty(daInputCreateTutor)) return;

                if (!int.TryParse(daInputCreateTutor, out var da)) return;

                var newStudent = await _studentService.GetByDaAsync(da);
                if (newStudent == null) return;

                var request = newStudent.Requests?.FirstOrDefault(r => r.Subject == "Devenir tuteur");
                if (request == null) return;

                var tutor = new Tutor
                {
                    FirstName = newStudent.FirstName,
                    LastName = newStudent.LastName,
                    Da = newStudent.Da,
                    Category = request.Subject
                };

                await _tutorService.CreateAsync(tutor);
                MessageBox.Show("Tuteur créé avec succès.", "Succès", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors de la création du tuteur : {ex.Message}", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

    }
}