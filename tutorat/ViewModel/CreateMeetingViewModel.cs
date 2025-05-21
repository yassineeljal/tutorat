using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using data.Model;
using tutorat.Service.MeetingService;
using tutorat.Service.StudentService;
using tutorat.Service.TutorService;

namespace tutorat.ViewModel
{
    public partial class CreateMeetingViewModel : ObservableObject
    {
        private readonly ITutorService _tutorService;
        private readonly IStudentService _studentService;
        private readonly IMeetingService _meetingService;

        public CreateMeetingViewModel(ITutorService tutorService, IStudentService studentService, IMeetingService meetingService)
        {
            _tutorService = tutorService;
            _studentService = studentService;
            _meetingService = meetingService;

        }

        [ObservableProperty]
        private string name;

        [ObservableProperty]
        private string description;

        [ObservableProperty]
        private DateTime date;

        [ObservableProperty]
        private string time;

        [ObservableProperty]
        private string tutorDa;

        [ObservableProperty]
        private string studentDa;

        [RelayCommand]
        private async Task CreateMeetingAsync()
        {

            if (string.IsNullOrWhiteSpace(name) ||
                string.IsNullOrWhiteSpace(description) ||
                date == null ||
                string.IsNullOrWhiteSpace(time) ||
                string.IsNullOrWhiteSpace(tutorDa) ||
                string.IsNullOrWhiteSpace(studentDa))
            {
                MessageBox.Show("Veuillez remplir tous les champs.", "Erreur", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            try
            {

                var timeMeeting = TimeSpan.Parse(time);
                var dateMeeting = date.Date.Add(timeMeeting);

                var tutor = await _tutorService.GetByDaAsync(int.Parse(tutorDa));
                var student = await _studentService.GetByDaAsync(int.Parse(studentDa));

                if (tutor == null || student == null)
                {
                    MessageBox.Show("Tuteur ou étudiant introuvable.", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                await _meetingService.CreateAsync(new Meeting
                {
                    Name = name,
                    Description = description,
                    DateMeeting = dateMeeting,
                    StudentId = student.Id,
                    TutorId = tutor.Id
                });

                MessageBox.Show("Rencontre créée avec succès !");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors de la création : {ex.Message}", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
