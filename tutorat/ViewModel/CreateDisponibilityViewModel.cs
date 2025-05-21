using System;
using System.Windows;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using data.Model;
using tutorat.Service.AvailabilityService;
using tutorat.Service.StudentService;
using tutorat.Service.TutorService;

namespace tutorat.ViewModel
{
    public partial class CreateDisponibilityViewModel : ObservableObject
    {
        private readonly IAvailabilityService _availabilityService;
        private readonly ITutorService _tutorService;
        private readonly IStudentService _studentService;

        public CreateDisponibilityViewModel(
            IAvailabilityService availabilityService,
            ITutorService tutorService,
            IStudentService studentService)
        {
            _availabilityService = availabilityService;
            _tutorService = tutorService;
            _studentService = studentService;
        }

        [ObservableProperty] private string status;
        [ObservableProperty] private string da;

        [ObservableProperty] private bool lundiChecked;
        [ObservableProperty] private string lundiStart;
        [ObservableProperty] private string lundiEnd;

        [ObservableProperty] private bool mardiChecked;
        [ObservableProperty] private string mardiStart;
        [ObservableProperty] private string mardiEnd;

        [ObservableProperty] private bool mercrediChecked;
        [ObservableProperty] private string mercrediStart;
        [ObservableProperty] private string mercrediEnd;

        [ObservableProperty] private bool jeudiChecked;
        [ObservableProperty] private string jeudiStart;
        [ObservableProperty] private string jeudiEnd;

        [ObservableProperty] private bool vendrediChecked;
        [ObservableProperty] private string vendrediStart;
        [ObservableProperty] private string vendrediEnd;

        [ObservableProperty] private bool samediChecked;
        [ObservableProperty] private string samediStart;
        [ObservableProperty] private string samediEnd;

        [ObservableProperty] private bool dimancheChecked;
        [ObservableProperty] private string dimancheStart;
        [ObservableProperty] private string dimancheEnd;

        [RelayCommand]
        private async Task SaveAsync()
        {
            if (!int.TryParse(Da, out var daValue))
            {
                MessageBox.Show("DA invalide.", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            Student student = null;
            Tutor tutor = null;

            if (Status == "Etudiant")
            {
                student = await _studentService.GetByDaAsync(daValue);
                if (student == null)
                {
                    MessageBox.Show($"Étudiant DA={daValue} introuvable.", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
            }
            else if (Status == "Tuteur")
            {
                tutor = await _tutorService.GetByDaAsync(daValue);
                if (tutor == null)
                {
                    MessageBox.Show($"Tuteur DA={daValue} introuvable.", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
            }
            else
            {
                MessageBox.Show("Sélectionnez ‘Etudiant’ ou ‘Tuteur’.", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            await CreateForDayAsync(DayOfWeek.Monday, LundiChecked, LundiStart, LundiEnd, student, tutor);
            await CreateForDayAsync(DayOfWeek.Tuesday, MardiChecked, MardiStart, MardiEnd, student, tutor);
            await CreateForDayAsync(DayOfWeek.Wednesday, MercrediChecked, MercrediStart, MercrediEnd, student, tutor);
            await CreateForDayAsync(DayOfWeek.Thursday, JeudiChecked, JeudiStart, JeudiEnd, student, tutor);
            await CreateForDayAsync(DayOfWeek.Friday, VendrediChecked, VendrediStart, VendrediEnd, student, tutor);
            await CreateForDayAsync(DayOfWeek.Saturday, SamediChecked, SamediStart, SamediEnd, student, tutor);
            await CreateForDayAsync(DayOfWeek.Sunday, DimancheChecked, DimancheStart, DimancheEnd, student, tutor);

            MessageBox.Show("Disponibilités enregistrées !", "Succès", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private async Task CreateForDayAsync(
            DayOfWeek day,
            bool isChecked,
            string startText,
            string endText,
            Student student,
            Tutor tutor)
        {
            if (!isChecked) return;

            if (!TimeSpan.TryParse(startText, out var start)
             || !TimeSpan.TryParse(endText, out var end)
             || end <= start)
            {
                MessageBox.Show($"Heures invalides pour {day}.", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            var newAvailability = new Availability
            {
                DayOfWeek = day,
                StartTime = start,
                EndTime = end,
                StudentId = Status == "Etudiant" ? student.Id : (int?)null,
                TutorId = Status == "Tuteur" ? tutor.Id : (int?)null
            };

            try
            {
                await _availabilityService.CreateAvailabilityAsync(newAvailability);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Erreur lors de l'enregistrement : " +
                    ex.GetBaseException().Message,
                    "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
