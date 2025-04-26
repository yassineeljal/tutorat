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
        public ObservableCollection<Tutor> TutorsSearch { get; set; } = new ObservableCollection<Tutor>();

        public TutorListViewModel(ITutorService tutorService)
        {
            _tutorService = tutorService;
            LoadTutors();

        }

        [ObservableProperty]
        private String daInput;

        [ObservableProperty]
        private Tutor selectedTutor;
        
        [ObservableProperty]
        [NotifyCanExecuteChangedFor(nameof(DeleteTutorCommand))]
        private Tutor selectedTutorSearch;

        private void LoadTutors()
        {
            _tutorService.Create(new Tutor
            {
                FirstName = "Alice",
                LastName = "Martin",
                Da = 98765
            });
            _tutorService.Create(new Tutor
            {
                FirstName = "Alice",
                LastName = "Martin",
                Da = 2
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
            var tutor = _tutorService.GetByDa(int.Parse(daInput));
            if (string.IsNullOrEmpty(daInput))
            {
                return;
            }
            if( tutor == null || TutorsSearch.FirstOrDefault(t => t.Da == tutor.Da) != null) {
                return;
            }
            else
            {
                TutorsSearch.Clear();
                TutorsSearch.Add(_tutorService.GetByDa(int.Parse(daInput)));
            }

        }

        private bool canDeleteTutor()
        {
            return SelectedTutorSearch != null;
        }

        [RelayCommand(CanExecute = nameof(canDeleteTutor))]
        private void DeleteTutor()
        {
            if (SelectedTutorSearch != null)
            {
                _tutorService.Delete(SelectedTutorSearch.Da);
                Tutors.Remove(SelectedTutorSearch);
                TutorsSearch.Clear();
                SelectedTutor = null;
            }
        }
    }
}
