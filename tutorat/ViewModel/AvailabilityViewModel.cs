using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using data.Model;
using tutorat.Service.AvailabilityService;

namespace tutorat.ViewModel
{
    public partial class AvailabilityViewModel : ObservableObject
    {
        private readonly IAvailabilityService _availabilityService;
        public ObservableCollection<DayOfWeek> Days { get; set; }

        [ObservableProperty]
        private DayOfWeek selectedDay;

        [ObservableProperty]
        private string startHour;

        [ObservableProperty]
        private string endHour;


        public AvailabilityViewModel(IAvailabilityService availabilityService)
        {
            _availabilityService=availabilityService;
            Days = new ObservableCollection<DayOfWeek>((DayOfWeek[])Enum.GetValues(typeof(DayOfWeek)));
            SelectedDay = DayOfWeek.Monday;

        }
        [RelayCommand]
        private void Save()
        {
            if (!TimeSpan.TryParse(StartHour, out TimeSpan start))
            {
                MessageBox.Show("Heure de début invalide (ex: 08:30)");
                return;
            }

            if (!TimeSpan.TryParse(EndHour, out TimeSpan end))
            {
                MessageBox.Show("Heure de fin invalide (ex: 10:00)");
                return;
            }

            if (end <= start)
            {
                MessageBox.Show("L'heure de fin doit être après l'heure de début.");
                return;
            }

            Availability availability = new Availability
            {
                DayOfWeek = SelectedDay,
                StartTime = start,
                EndTime = end,
            };


            MessageBox.Show("ddddd !");

            _availabilityService.CreateAvailability(availability);

            MessageBox.Show("Disponibilité enregistrée !");
        }



    }
}
