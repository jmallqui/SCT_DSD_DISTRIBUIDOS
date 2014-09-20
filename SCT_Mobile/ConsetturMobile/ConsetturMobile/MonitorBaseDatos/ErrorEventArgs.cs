using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace ConsetturMobile
{
    public class ErrorEventArgs: EventArgs
    {
        public Exception CustomeError { get; set; }
    }
}
