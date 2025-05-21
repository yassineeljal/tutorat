using System.Collections.ObjectModel;
using System.Windows;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using data.Model;
using tutorat.Service.RequestService;
using tutorat.Service.StudentService;

namespace tutorat.ViewModel
{
    public partial class StudentRequestViewModel : ObservableObject
    {
        public ObservableCollection<string> Categories { get; set; } = new ObservableCollection<string>
        {
            "IDO",
            "Interface humain machine",
            "Projet Web",
            "Application pour entreprise",
            "Infonuagique",
        };

        public ObservableCollection<string> Subjects { get; set; } = new ObservableCollection<string>
        {
            "Devenir tuteur",
            "Demander de l'aide"
        };



        private readonly IRequestService _requestService;
        private readonly IStudentService _studentService;

        public StudentRequestViewModel(IRequestService requestService, IStudentService studentService)
        {
            _requestService = requestService;
            _studentService = studentService;
            SelectedCategory = Categories.FirstOrDefault();
            SelectedSubject = Subjects.FirstOrDefault();

        }
        [ObservableProperty]
        private String selectedCategory;
        [ObservableProperty]
        private string selectedSubject;
        [ObservableProperty]
        private String noteInput;
        [ObservableProperty]
        private String daInput;

        [RelayCommand]
        private async Task CreateRequestAsync()
        {
            try
            {
                if (string.IsNullOrWhiteSpace(selectedSubject) ||
                    string.IsNullOrWhiteSpace(selectedCategory) ||
                    string.IsNullOrWhiteSpace(noteInput) ||
                    string.IsNullOrWhiteSpace(daInput))
                {
                    MessageBox.Show("Tous les champs sont requis.", "Erreur", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                if (!int.TryParse(daInput, out var da) || !int.TryParse(noteInput, out var note))
                {
                    MessageBox.Show("DA ou note invalide.", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                var student = await _studentService.GetByDaAsync(da);
                if (student == null)
                {
                    MessageBox.Show("Étudiant introuvable.", "Erreur", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                var request = new Request
                {
                    Subject = selectedSubject,
                    Category = selectedCategory,
                    Note = note,
                    StudentId = student.Id
                };

                await _requestService.CreateRequestAsync(request);
                MessageBox.Show("Demande envoyée avec succès.", "Succès", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors de l'envoi de la demande : {ex.Message}", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

    }
}
