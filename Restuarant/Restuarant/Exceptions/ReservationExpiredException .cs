using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restuarant.Exceptions
{
    internal class ReservationExpiredException:Exception
    {
        public ReservationExpiredException(string message) : base(message) { }
    }
}
