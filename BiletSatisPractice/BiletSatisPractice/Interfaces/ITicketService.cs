using BiletSatisPractice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiletSatisPractice.Interfaces
{
    internal interface ITicketService
    {
        Task<Ticket> BuyTicketAsync(int eventId);
        Task UseTicketAsync(int ticketId);
    }
}
