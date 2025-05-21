using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using data.Model;
using tutorat.Service.StudentService;
using tutorat.Service.TeacherService;
using tutorat.Service.TutorService;
using System.Windows;


namespace tutorat.ViewModel
{
    public partial class LoginViewModel : ObservableObject
    {
        private readonly IStudentService _studentService;
        private readonly ITutorService _tutorService;
        private readonly ITeacherService _teacherService;

        public LoginViewModel(IStudentService studentService,
                              ITutorService tutorService,
                              ITeacherService teacherService)
        {
            _studentService = studentService;
            _tutorService = tutorService;
            _teacherService = teacherService;
        }

        public List<string> Roles { get; } = new() { "Student", "Tutor", "Teacher" };

        [ObservableProperty]
        private string da;

        [ObservableProperty]
        private string password;

        [ObservableProperty]
        private string selectedRole;

        [ObservableProperty]
        private string statusMessage;

        [RelayCommand]
        private async Task LoginAsync()
        {
            MessageBox.Show("Entrée");
            if (string.IsNullOrWhiteSpace(Da) || string.IsNullOrWhiteSpace(Password) || string.IsNullOrWhiteSpace(SelectedRole))
            {
                StatusMessage = "Veuillez remplir tous les champs.";
                return;
            }

            switch (SelectedRole)
            {
                case "Student":
                    var students = await _studentService.GetAllAsync();
                    var s = students.FirstOrDefault(u => u.Da == int.Parse(Da) && u.Password == Password);
                    if (s != null)
                    {
                        StatusMessage = $"Bienvenue étudiant {s.FirstName} !";
                        new View.StudentDashboard().Show();
                        CloseLoginWindow();
                    }
                    else
                    {
                        StatusMessage = "Identifiants étudiant invalides.";
                    }
                    break;

                case "Tutor":
                    var tutors = await _tutorService.GetAllAsync();
                    var t = tutors.FirstOrDefault(u => u.Da == int.Parse(Da) && u.Password == Password);
                    if (t != null)
                    {
                        StatusMessage = $"Bienvenue tuteur {t.FirstName} !";
                        new View.TutorDashboard().Show();
                        CloseLoginWindow();
                    }
                    else
                    {
                        StatusMessage = "Identifiants tuteur invalides.";
                    }
                    break;

                case "Teacher":
                    var teachers = await _teacherService.GetAllAsync();
                    var te = teachers.FirstOrDefault(u => u.Da == int.Parse(Da) && u.Password == Password);
                    if (te != null)
                    {
                        StatusMessage = $"Bienvenue enseignant {te.FirstName} !";
                        new View.TeacherDashboard().Show();
                        CloseLoginWindow();
                    }
                    else
                    {
                        StatusMessage = "Identifiants enseignant invalides.";
                    }
                    break;

                default:
                    StatusMessage = "Veuillez sélectionner un rôle valide.";
                    break;
            }
        }

        private void CloseLoginWindow()
        {
            Application.Current.MainWindow.Close();
        }
    }
    }
