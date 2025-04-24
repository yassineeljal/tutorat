using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using data.Model;
using tutorat.Service.TutorService;

namespace tutorat.ViewModel
{
    public partial class TutorListViewModel : ObservableObject
    {
        private readonly ITutorService _tutorService;
        public ObservableCollection<Tutor> Tutors { get; set; } = new ObservableCollection<Tutor>();

        public TutorListViewModel(ITutorService tutorService)
        {
            _tutorService = tutorService;
            LoadTutors();

        }

        [ObservableProperty]
        private String daInput;

        [ObservableProperty]
        private Tutor selectedTutor;

        private void LoadTutors()
        {
            _tutorService.Create(new Tutor
            {
                FirstName = "Alice",
                LastName = "Martin",
                Da = 98765
            });
            var tutors = _tutorService.GetAll();
            foreach (var tutor in tutors)
            {
                Tutors.Add(tutor);
            }
        }
        [RelayCommand]
        private void SearchTutor()
        {
            Tutors.Clear();
            Tutors.Add(_tutorService.GetByDa(int.Parse(daInput)));
        }
    }
}
