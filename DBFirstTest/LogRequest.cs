using System;
using System.Collections.Generic;

namespace DBFirstTest
{
    public partial class LogRequest
    {
        public uint Id { get; set; }
        public string RequestHeaders { get; set; }
        public string RequestBody { get; set; }

        public Log IdNavigation { get; set; }
    }
}
