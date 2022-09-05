using System;
using System.Diagnostics;
using System.Windows.Threading;

namespace SharpClock.Logic
{
    public class StopwatchControl
    {

        Stopwatch stopwatch = new Stopwatch();
        public DispatcherTimer timer = new DispatcherTimer();

        public StopwatchControl()
        {
            timer.Interval = new TimeSpan(0, 0, 0, 0, 1);
            timer.Start();
        }

        public void StartStopwatch()
        {
            stopwatch.Start();
            timer.Start();
        }

        public void PauseStopwatch()
        {
            stopwatch.Stop();
            timer.Stop();
        }

        public string SaveStopwatch()
        {
            PauseStopwatch();
            string elapsedTime = GetElapsedTime();
            ResetStopwatch();
            return elapsedTime;
        }

        public string GetElapsedTime()
        {
            TimeSpan tspan = stopwatch.Elapsed;
            string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}", tspan.Hours, tspan.Minutes, tspan.Seconds);
            return elapsedTime;
        }

        public void ResetStopwatch()
        {
            stopwatch.Reset();
        }
    }
}
