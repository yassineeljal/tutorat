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
        private void CreateMeeting()
        {
            MessageBox.Show("entrer");
            if (name == null && description == null && date == null && time == null && tutorDa == null && studentDa == null)
            {
                MessageBox.Show("veuillez remplire tout les gens");
                return;

            }

            else
            {
                MessageBox.Show("else");

                var timeMeeting = TimeSpan.Parse(time);
                var dateMeeting = date.Date.Add(timeMeeting);

                var tutor = _tutorService.GetByDa(int.Parse(tutorDa));
                var student = _studentService.GetByDa(int.Parse(studentDa));

                _meetingService.Create(new Meeting
                {
                    Name = name,
                    Description = description,
                    DateMeeting = dateMeeting,
                    StudentId = student.Id,
                    TutorId = tutor.Id

                });
                MessageBox.Show("fini");


            }
        }
    }
}
