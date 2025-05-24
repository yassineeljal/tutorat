

using CommunityToolkit.Mvvm.ComponentModel;
using data.Model;
using System.Collections.ObjectModel;
using tutorat.Service.MeetingService;

namespace tutorat.ViewModel
{
    public partial class MeetingViewModel : ObservableObject
    {
        private readonly IMeetingService _meetingService;
        public ObservableCollection<Meeting> Meetings { get; set; } = new ObservableCollection<Meeting>();

        [ObservableProperty]
        private String idInput;
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
            });
            Meetings.Add(new Meeting
            {
                Id = 2,
                Name = "Meeting 2",
                Description = "Description 2",
                DateMeeting = DateTime.Now.AddDays(1),
            });

            var meetings = _meetingService.GetAll();
            foreach (var meeting in meetings)
            {
                Meetings.Add(meeting);
            }
        }



    }
}
