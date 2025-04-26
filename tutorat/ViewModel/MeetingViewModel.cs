

using CommunityToolkit.Mvvm.ComponentModel;
using data.Model;
using System.Collections.ObjectModel;
using tutorat.Service.MeetingService;

namespace tutorat.ViewModel
{
    public class MeetingViewModel : ObservableObject
    {
        private readonly IMeetingService _meetingService;
        public ObservableCollection<Meeting> Meetings { get; set; } = new ObservableCollection<Meeting>();
        public MeetingViewModel(IMeetingService meetingService)
        {
            _meetingService = meetingService;
            LoadMeetings();
        }

        private void LoadMeetings()
        {
            Meetings.Add(new Meeting
            {
                Id = 1,
                Name = "Meeting 1",
                Description = "Description 1",
                DateMeeting = DateTime.Now,
                Tutor = new Tutor { FirstName = "Alice", LastName = "Martin", Da = 98765 },
                Student = new Student { FirstName = "Bob", LastName = "Dupont", Da = 12345 }
            });
            Meetings.Add(new Meeting
            {
                Id = 2,
                Name = "Meeting 2",
                Description = "Description 2",
                DateMeeting = DateTime.Now.AddDays(1),
                Tutor = new Tutor { FirstName = "Charlie", LastName = "Brown", Da = 54321 },
                Student = new Student { FirstName = "David", LastName = "Smith", Da = 67890 }
            });

            var meetings = _meetingService.GetAll();
            foreach (var meeting in meetings)
            {
                Meetings.Add(meeting);
            }
        }

    }
}
