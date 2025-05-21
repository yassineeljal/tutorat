

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
            LoadMeetingsAsync();
        }

        private async Task LoadMeetingsAsync()
        {
            var meetings = await _meetingService.GetAllAsync();

            Meetings.Clear();
            foreach (var meeting in meetings)
            {
                Meetings.Add(meeting);
            }
        }




    }
}
