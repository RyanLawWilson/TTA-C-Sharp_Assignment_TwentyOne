using System;
using System.Collections.Generic;
using System.Text;

namespace Casino
{
    public class FraudException : Exception
    {
        // Inheriting Exception's constructors.
        public FraudException()
            : base() { }
        public FraudException(string message)
            : base(message) { }
    }
}
