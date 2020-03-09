using System;
using System.Collections.Generic;
using System.Text;

namespace TwentyOne
{
    // Calling something an entity implies that it deals with a DB
    // Entity is a DB object
    class ExceptionEntity
    {
        public int Id { get; set; }
        public string ExceptionType { get; set; }
        public string ExceptionMessage { get; set; }
        public DateTime TimeStamp { get; set; }
    }
}
