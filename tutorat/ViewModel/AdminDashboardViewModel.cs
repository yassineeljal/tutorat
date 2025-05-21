using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using data.Model;
using System.Windows;
using tutorat.Service.StudentService;
using tutorat.Service.TeacherService;
using tutorat.Service.TutorService;

namespace tutorat.ViewModel
{
    public partial class AdminDashboardViewModel : ObservableObject
    {
        private readonly IStudentService _studentService;
        private readonly ITutorService _tutorService;
        private readonly ITeacherService _teacherService;

        public AdminDashboardViewModel(IStudentService studentService, ITutorService tutorService, ITeacherService teacherService)
        {
            _studentService = studentService;
            _tutorService = tutorService;
            _teacherService = teacherService;

        }

        [ObservableProperty]
        private string studentFirstName;
        [ObservableProperty]
        private string studentLastName;
        [ObservableProperty]
        private string studentDa;
        [ObservableProperty]
        private string tutorFirstName;
        [ObservableProperty]
        private string tutorLastName;
        [ObservableProperty]
        private string tutorDa;
        [ObservableProperty]
        private string tutorCategory;
        [ObservableProperty]
        private string teacherFirstName;
        [ObservableProperty]
        private string teacherLastName;

        [RelayCommand]
        public async Task AddStudentAsync()
        {
            try
            {
                var student = new Student
                {
                    FirstName = StudentFirstName,
                    LastName = StudentLastName,
                    Da = int.Parse(StudentDa),
                };

                await _studentService.CreateAsync(student);
                MessageBox.Show("Étudiant ajouté");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors de l'ajout de l'étudiant : {ex.Message}");
            }
        }

        [RelayCommand]
        public async Task DeleteStudentAsync()
        {
            try
            {
                var student = await _studentService.GetByDaAsync(int.Parse(StudentDa));
                if (student != null)
                {
                    await _studentService.DeleteAsync(student.Id);
                    MessageBox.Show("Étudiant supprimé");
                }
                else
                {
                    MessageBox.Show("Étudiant introuvable");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors de la suppression de l'étudiant : {ex.Message}");
            }
        }

        [RelayCommand]
        public async Task AddTutorAsync()
        {
            try
            {
                var tutor = new Tutor
                {
                    FirstName = TutorFirstName,
                    LastName = TutorLastName,
                    Da = int.Parse(TutorDa),
                    Category = TutorCategory
                };

                await _tutorService.CreateAsync(tutor);
                MessageBox.Show("Tuteur ajouté");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors de l'ajout du tuteur : {ex.Message}");
            }
        }


        [RelayCommand]
        public async Task DeleteTutorAsync()
        {
            try
            {
                await _tutorService.DeleteAsync(int.Parse(TutorDa));
                MessageBox.Show("Tuteur supprimé");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors de la suppression du tuteur : {ex.Message}");
            }
        }

        [RelayCommand]
        public async Task AddTeacherAsync()
        {
            try
            {
                var teacher = new Teacher
                {
                    FirstName = TeacherFirstName,
                    LastName = TeacherLastName,
                };

                await _teacherService.CreateAsync(teacher);
                MessageBox.Show("Enseignant ajouté");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors de l'ajout de l'enseignant : {ex.Message}");
            }
        }

        [RelayCommand]
        public async Task DeleteTeacherAsync()
        {
            try
            {
                var teacher = await _teacherService.GetByLastNameAsync(TeacherLastName);
                if (teacher != null)
                {
                    await _teacherService.DeleteAsync(teacher.Id);
                    MessageBox.Show("Enseignant supprimé");
                }
                else
                {
                    MessageBox.Show("Enseignant introuvable");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors de la suppression de l'enseignant : {ex.Message}");
            }
        }


    }
}
