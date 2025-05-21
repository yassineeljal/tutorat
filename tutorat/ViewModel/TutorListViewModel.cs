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
            LoadTutorsAsync();

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

        private async Task LoadTutorsAsync()
        {
            try
            {
                var tutors = await _tutorService.GetAllAsync();
                Tutors.Clear();
                foreach (var tutor in tutors)
                {
                    Tutors.Add(tutor);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors du chargement des tuteurs : {ex.Message}", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        [RelayCommand]
        private async Task SearchTutorAsync()
        {
            if (string.IsNullOrWhiteSpace(daInput)) return;

            if (!int.TryParse(daInput, out var da)) return;

            try
            {
                var tutor = await _tutorService.GetByDaAsync(da);
                if (tutor == null || TutorsSearch.Any(t => t.Da == tutor.Da)) return;

                TutorsSearch.Clear();
                TutorsSearch.Add(tutor);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors de la recherche : {ex.Message}", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private bool CanDeleteTutor()
        {
            return SelectedTutorSearch != null;
        }

        [RelayCommand(CanExecute = nameof(CanDeleteTutor))]
        private async Task DeleteTutorAsync()
        {
            if (SelectedTutorSearch == null) return;

            try
            {
                await _tutorService.DeleteAsync(SelectedTutorSearch.Da);
                Tutors.Remove(SelectedTutorSearch);
                TutorsSearch.Clear();
                SelectedTutor = null;
                MessageBox.Show("Tuteur supprimé.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors de la suppression : {ex.Message}", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
