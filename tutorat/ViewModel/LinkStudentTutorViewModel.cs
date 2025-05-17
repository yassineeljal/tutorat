using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using tutorat.Service.StudentService;
using tutorat.Service.TutorService;
using tutorat.Service.RequestService;
using data.Model;

namespace tutorat.ViewModel
{
    public partial class LinkStudentTutorViewModel : ObservableObject
    {
        public ObservableCollection<Tutor> Tutors { get; set; } = new();
        public ObservableCollection<Request> Requests { get; set; } = new();

        private readonly ITutorService _tutorService;
        private readonly IStudentService _studentService;
        private readonly IRequestService _requestService;

        public LinkStudentTutorViewModel(ITutorService tutorService,IStudentService studentService, IRequestService requestService)
        {
            _tutorService = tutorService;
            _studentService = studentService;
            _requestService = requestService;

            LoadRequests();
            LoadTutors();
        }

        [ObservableProperty]
        private Request selectedRequest;

        [ObservableProperty]
        private Tutor selectedTutor;

        [RelayCommand]
        public void LinkStudentToTutor()
        {
            if (SelectedRequest == null || SelectedTutor == null)
                return;

            // Récupération du Student à partir de la Request
            var student = _studentService.GetById(SelectedRequest.StudentId);

            if (student == null)
            {
                System.Windows.MessageBox.Show("Étudiant introuvable.");
                return;
            }

            if (student.IsLinked || SelectedTutor.IsLinked)
            {
                System.Windows.MessageBox.Show("L'étudiant ou le tuteur est déjà lié.");
                return;
            }

            // Mise à jour
            student.TutorId = SelectedTutor.Id;
            student.IsLinked = true;
            SelectedTutor.IsLinked = true;

            _studentService.Update(student);
            _tutorService.Update(SelectedTutor);

            System.Windows.MessageBox.Show(
                $"{student.FirstName} {student.LastName} a été lié à {SelectedTutor.FirstName} {SelectedTutor.LastName}.");
        }

        private void LoadRequests()
        {
            var requests = _requestService.GetAllRequests();

            Requests.Clear();
            foreach (var request in requests)
            {
                if (request.Subject == "Demander de l'aide")
                {
                    var student = _studentService.GetById(request.StudentId);
                    if (student != null && !student.IsLinked)
                    {
                        Requests.Add(request);
                    }
                }
            }
        }

        private void LoadTutors()
        {
            var tutors = _tutorService.GetAll();
            Tutors.Clear();
            foreach (var tutor in tutors)
            {
                if (!tutor.IsLinked)
                {
                    Tutors.Add(tutor);
                }
            }
        }
    }
}
