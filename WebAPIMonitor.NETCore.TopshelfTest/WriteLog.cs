using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Timers;

namespace WebAPIMonitor.NETCore.TopshelfTest
{
    public class WriteLog
    {
        private readonly Timer handleTimer;

        public WriteLog()
        {
            this.handleTimer = new Timer
            {
                Enabled = true,
                Interval = 60000
            };
            this.handleTimer.Elapsed += HandleTimer_Elapsed;
        }

        private void HandleTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            this.handleTimer.Enabled = false;

            File.AppendAllText(@"C:\Users\MI-DIT\Documents\TempEntityCode\log.txt", @"12345\r\n");

            this.handleTimer.Enabled = true;
        }

        public void StartWriteLog()
        {
            this.handleTimer.Start();
        }

        public void StopWriteLog()
        {
            this.handleTimer.Enabled = false;
            this.handleTimer.Stop();
            this.handleTimer.Close();
            this.handleTimer.Dispose();
        }
    }
}
