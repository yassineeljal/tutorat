using System.Collections.ObjectModel;
using System.Windows;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using data.Model;
using tutorat.Service.StudentService;
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
        private String daInputCreateTutor;

        [ObservableProperty]
        [NotifyCanExecuteChangedFor(nameof(DeleteTutorCommand))]
        private Tutor selectedTutorSearch;

        private void LoadTutors()
        {
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
            MessageBox.Show("23432");
            if (SelectedTutorSearch != null)
            {
                _tutorService.Delete(SelectedTutorSearch.Da);
                Tutors.Remove(SelectedTutorSearch);
                TutorsSearch.Clear();
                SelectedTutor = null;
                MessageBox.Show("fregagfsda");
            }
            else
            {
                return;
            }
        }       
    }
}
