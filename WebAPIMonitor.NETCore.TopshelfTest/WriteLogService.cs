using System;
using System.Collections.Generic;
using System.Text;
using Topshelf;

namespace WebAPIMonitor.NETCore.TopshelfTest
{
    public class WriteLogService : ServiceControl
    {
        private WriteLog writeLog = new WriteLog();

        public bool Start(HostControl hostControl)
        {
            writeLog.StartWriteLog();
            return true;
        }

        public bool Stop(HostControl hostControl)
        {
            writeLog.StopWriteLog();
            return true;
        }
    }
}
