using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;
using data.Model;

namespace tutorat.ViewModel
{
    public class AvailabilityViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<DayOfWeek> Days { get; set; }

        private DayOfWeek _selectedDay;
        public DayOfWeek SelectedDay
        {
            get => _selectedDay;
            set
            {
                _selectedDay = value;
                OnPropertyChanged();
            }
        }

        private string _startHour;
        public string StartHour
        {
            get => _startHour;
            set
            {
                _startHour = value;
                OnPropertyChanged();
            }
        }

        private string _endHour;
        public string EndHour
        {
            get => _endHour;
            set
            {
                _endHour = value;
                OnPropertyChanged();
            }
        }

        public ICommand SaveCommand { get; }

        public AvailabilityViewModel()
        {
            Days = new ObservableCollection<DayOfWeek>((DayOfWeek[])Enum.GetValues(typeof(DayOfWeek)));
            SelectedDay = DayOfWeek.Monday;

            SaveCommand = new RelayCommand(Save);
        }

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
                StudentId = 1 // juste un test
            };

            MessageBox.Show("Disponibilité enregistrée !");
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }

    // Simple implémentation de RelayCommand
    public class RelayCommand : ICommand
    {
        private readonly Action _execute;
        public RelayCommand(Action execute) => _execute = execute;

        public event EventHandler CanExecuteChanged;
        public bool CanExecute(object parameter) => true;

        public void Execute(object parameter) => _execute();
    }
}
