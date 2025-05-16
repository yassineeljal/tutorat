using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using tutorat.Service.StudentService;
using tutorat.Service.TutorService;

namespace tutorat.ViewModel
{
    public partial class LinkStudentTutorViewModel: ObservableObject
    {
        public ObservableCollection<Tutor> Tutors { get; set; } =  new ObservableCollection<Tutor>();
        public ObservableCollection<Student> Students { get; set; } = new ObservableCollection<Student>();

        private readonly ITutorService _tutorService;
        private readonly IStudentService _studentService;
        public LinkStudentTutorViewModel(ITutorService tutorService, IStudentService studentService)
        {
            _tutorService = tutorService;
            _studentService = studentService;
            LoadStudent();
            LoadTutors();

        }

        [ObservableProperty]
        private Student selectedStudent;


        [ObservableProperty]
        private Tutor selectedTutor;



        [RelayCommand]
        public void LinkStudentToTutor()
        {
            if (SelectedStudent == null || SelectedTutor == null)
                return;

            if (SelectedStudent.IsLinked || SelectedTutor.IsLinked)
            {
                System.Windows.MessageBox.Show("L'étudiant ou le tuteur est déjà lié.");
                return;
            }

            SelectedStudent.TutorId = SelectedTutor.Id;
            SelectedStudent.IsLinked = true;
            SelectedTutor.IsLinked = true;

            _studentService.Update(SelectedStudent);
            _tutorService.Update(SelectedTutor);

            System.Windows.MessageBox.Show(
                $"{SelectedStudent.FirstName} {SelectedStudent.LastName} a été lié à {SelectedTutor.FirstName} {SelectedTutor.LastName}.");
        }

        private  void LoadStudent()
        {
            var students = _studentService.GetAll();

            foreach (var student in students)
            {
                if (student.Requests == null)
                    continue;

                foreach (var request in student.Requests)
                {
                    if (request.Subject == "Demander de l'aide" && !student.IsLinked)
                    {
                        Students.Add(student);
                        break;
                    }
                }
            }
        }

        private void LoadTutors()
        {
            var tutors = _tutorService.GetAll();
            foreach (var tutor in tutors)
            {
                if (tutor.IsLinked)
                {
                    continue;
                }
                else
                {
                    Tutors.Add(tutor);
                }
            }
        }
    }
}
