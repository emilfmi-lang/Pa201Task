using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiletSatisPractice.Exceptions
{
    internal class EventExpiredException:Exception 
    {
        public EventExpiredException(string message) : base(message) { }
    }
}
