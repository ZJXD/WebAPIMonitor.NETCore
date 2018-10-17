using System;
using System.Collections.Generic;

namespace DBFirstTest
{
    public partial class Application
    {
        public Application()
        {
            Log = new HashSet<Log>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Token { get; set; }
        public sbyte IsDelete { get; set; }

        public ICollection<Log> Log { get; set; }
    }
}
