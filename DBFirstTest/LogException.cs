using System;
using System.Collections.Generic;

namespace DBFirstTest
{
    public partial class LogException
    {
        public uint Id { get; set; }
        public string ExceptionMessage { get; set; }

        public Log IdNavigation { get; set; }
    }
}
