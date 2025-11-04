using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiletSatisPractice.Exceptions
{
    internal class TicketAlreadyUsedException: Exception
    {
        public TicketAlreadyUsedException(string message) : base(message){ }
    }
}
