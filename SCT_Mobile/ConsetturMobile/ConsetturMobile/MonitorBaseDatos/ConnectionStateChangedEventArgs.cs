using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace ConsetturMobile
{
    public class ConnectionStateChangedEventArgs : EventArgs
    {
        public bool IsConnected { get; set; }
    }
}
