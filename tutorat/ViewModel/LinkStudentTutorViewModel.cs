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

            LoadRequestsAsync();
            LoadTutorsAsync();
        }

        [ObservableProperty]
        private Request selectedRequest;

        [ObservableProperty]
        private Tutor selectedTutor;

        [RelayCommand]
        public async Task LinkStudentToTutorAsync()
        {
            if (SelectedRequest == null || SelectedTutor == null)
                return;

            var student = await _studentService.GetByIdAsync(SelectedRequest.StudentId);

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

            student.TutorId = SelectedTutor.Id;
            student.IsLinked = true;
            SelectedTutor.IsLinked = true;

            await _studentService.UpdateAsync(student);
            await _tutorService.UpdateAsync(SelectedTutor);

            System.Windows.MessageBox.Show(
                $"{student.FirstName} {student.LastName} a été lié à {SelectedTutor.FirstName} {SelectedTutor.LastName}.");
        }


        private async Task LoadRequestsAsync()
        {
            var requests = await _requestService.GetAllRequestsAsync();

            Requests.Clear();
            foreach (var request in requests)
            {
                if (request.Subject == "Demander de l'aide")
                {
                    var student = await _studentService.GetByIdAsync(request.StudentId);
                    if (student != null && !student.IsLinked)
                    {
                        Requests.Add(request);
                    }
                }
            }
        }


        private async Task LoadTutorsAsync()
        {
            var tutors = await _tutorService.GetAllAsync();

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
