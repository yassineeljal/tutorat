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
        public void AddStudent()
        {
            try
            {
                var student = new Student
                {
                    FirstName = StudentFirstName,
                    LastName = StudentLastName,
                    Da = int.Parse(StudentDa),
                };

                _studentService.Create(student);
                MessageBox.Show("Étudiant ajouté");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors de l'ajout de l'étudiant : {ex.Message}");
            }
        }

        [RelayCommand]
        public void DeleteStudent()
        {
                var student = _studentService.GetByDa(int.Parse(StudentDa));
                _studentService.Delete(student.Id);
                MessageBox.Show("Étudiant supprimé");

        }

        [RelayCommand]
        public void AddTutor()
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
                _tutorService.Create(tutor);
                MessageBox.Show("Tuteur ajouté");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors de l'ajout du tuteur : {ex.Message}");
            }
        }

        [RelayCommand]
        public void DeleteTutor()
        {
            try
            {
                _tutorService.Delete(int.Parse(TutorDa));
                MessageBox.Show("Tuteur supprimé");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors de la suppression du tuteur : {ex.Message}");
            }
        }

        [RelayCommand]
        public void AddTeacher()
        {
            try
            {
                var teacher = new Teacher
                {
                    FirstName = TeacherFirstName,
                    LastName = TeacherLastName,
                };
                _teacherService.Create(teacher);
                MessageBox.Show("Enseignant ajouté");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors de l'ajout de l'enseignant : {ex.Message}");
            }
        }

        [RelayCommand]
        public void DeleteTeacher()
        {
            try
            {
                var teacher = _teacherService.GetByLastName(TeacherLastName);
                _teacherService.Delete(teacher.Id);
                MessageBox.Show("Enseignant supprimé");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors de la suppression de l'enseignant : {ex.Message}");
            }
        }


    }
}
