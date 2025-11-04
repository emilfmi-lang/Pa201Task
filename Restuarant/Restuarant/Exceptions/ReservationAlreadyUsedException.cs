using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restuarant.Exceptions
{
    internal class ReservationAlreadyUsedException:Exception
    {
        public ReservationAlreadyUsedException(string message) : base(message) { }
    }
}
