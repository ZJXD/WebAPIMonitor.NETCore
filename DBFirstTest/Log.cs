using System;
using System.Collections.Generic;

namespace DBFirstTest
{
    public partial class Log
    {
        public uint Id { get; set; }
        public int? ApplicationId { get; set; }
        public string ApplicationName { get; set; }
        public string HttpMethod { get; set; }
        public string Url { get; set; }
        public DateTime? RequestTime { get; set; }
        public DateTime? ResponseTime { get; set; }
        public double? ExecuteMilliseconds { get; set; }
        public string Ip { get; set; }
        public string Host { get; set; }
        public string Browser { get; set; }
        public sbyte? IsUntreatedException { get; set; }
        public DateTime? GmtCreate { get; set; }

        public Application Application { get; set; }
        public LogException LogException { get; set; }
        public LogRequest LogRequest { get; set; }
        public LogResponse LogResponse { get; set; }
    }
}
