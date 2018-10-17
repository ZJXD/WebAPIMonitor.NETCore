using System;
using System.Collections.Generic;

namespace DBFirstTest
{
    public partial class LogResponse
    {
        public uint Id { get; set; }
        public string ResponseHeaders { get; set; }
        public string ResponseBody { get; set; }

        public Log IdNavigation { get; set; }
    }
}
