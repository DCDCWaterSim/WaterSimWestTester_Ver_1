using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Timers;

namespace TimerTool
{
    
    public class TimeMonitor
    {
        const int FDefaultInterval = 10;
        Timer FTheTimer;
        long FTimeCount = 0;
        long FInterval = 0;
        long FStartTime = 0;
        
        public TimeMonitor()
        {
            FTheTimer = new Timer(FDefaultInterval);
            FInterval = FDefaultInterval;
            FTheTimer.Enabled = false;
            FTheTimer.Elapsed += new ElapsedEventHandler(TimeMonitor_Tick);
        }

        public TimeMonitor(long interval)
        {
            FTheTimer = new Timer(interval);
            FInterval = interval;
            FTheTimer.Enabled = false;
            FTheTimer.Elapsed += new ElapsedEventHandler(TimeMonitor_Tick);
        }
        public void Start()
        {
            FStartTime = FTimeCount;

            FTheTimer.Start();
        }

        public void Stop()
        {
            FTheTimer.Stop();
        }

        public void Reset()
        {
            FTheTimer.Stop();
            FTimeCount = 0;
        }
        private void TimeMonitor_Tick(object sender, EventArgs e)
        {
            FTimeCount++;
        }

        public long TimeMs
        {
            get { return (FTimeCount-FStartTime) * FInterval; } 
        }


        public double TimeSec
        {
            get
            {
                double temp = 0;
                double dInterval = FInterval;
                double dTimeCount = (FTimeCount - FStartTime);
                temp = (dTimeCount * dInterval) / 1000.0;
                return temp;
            }
        }

    }
}
