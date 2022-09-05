using SharpClock.Logic;
using System;
using System.Collections.Generic;
using System.Windows;

namespace SharpClock
{
    /*  TODO
     * 
     * Možnost schovat listview
     * Jiné zobrazení stopek (čas nohoře, záznamy dole)
     * Předělání stopek a listview na samostatné View/Page (naučit se rozdíl)
     * 
     * Přejmenování proměn tak ať je to více univerzální
     */
    public partial class MainWindow : Window
    {

        List<Lesson> lessons = new List<Lesson>();
        SaveLoadManager fileManager = new SaveLoadManager();
        StopwatchControl swTimer = new StopwatchControl();

        public MainWindow()
        {
            InitializeComponent();
            UpdateListView();

            //Delegate for UI update (slow in debug mode)
            swTimer.timer.Tick += new EventHandler(UpdateClockUI);
        }

        private void UpdateClockUI(object sender, EventArgs e)
        {
            MyClock.Text = swTimer.GetElapsedTime();
        }

        private void startBtn_Click(object sender, RoutedEventArgs e)
        {
            swTimer.StartStopwatch();
        }

        private void pauseBtn_Click(object sender, RoutedEventArgs e)
        {
            swTimer.PauseStopwatch();
        }

        private void restartBtn_Click(object sender, RoutedEventArgs e)
        {
            swTimer.ResetStopwatch();
        }

        private void saveBtn_Click(object sender, RoutedEventArgs e)
        {
            fileManager.AddNewRecord(swTimer.SaveStopwatch());

            UpdateListView();

            swTimer.ResetStopwatch();
            UpdateClockUI(sender, e);
        }

        private void UpdateListView()
        {
            lessons.Clear();
            lessons = fileManager.GetRecords();
            listViewLessons.ItemsSource = null;
            listViewLessons.Items.Clear();
            listViewLessons.ItemsSource = lessons;
        }
    }
}
