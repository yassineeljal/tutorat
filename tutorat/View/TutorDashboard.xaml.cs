﻿using System.Windows;

namespace tutorat.View
{
    public partial class TutorDashboard : Window
    {
        public TutorDashboard()
        {
            InitializeComponent();
        }



        private void OnOpenCreateMeeting(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new CreateMeeting());
        }

        private void OnOpenAvailability(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new CreateDisponibility()); 
        }
        private void OnLogoutClick(object sender, RoutedEventArgs e)
        {
            var loginWindow = new Login();
            loginWindow.Show();
            this.Close();
        }

    }
}
