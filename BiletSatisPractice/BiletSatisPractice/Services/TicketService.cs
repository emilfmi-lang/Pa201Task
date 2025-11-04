using BiletSatisPractice.Data;
using BiletSatisPractice.Exceptions;
using BiletSatisPractice.Interfaces;
using BiletSatisPractice.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiletSatisPractice.Services
{
    internal class TicketService : ITicketService
    {
        private readonly TicketDbContext _context;

        public TicketService(TicketDbContext context)
        {
            _context = context;
        }
        public async Task<Ticket> BuyTicketAsync(int eventId)
        {
            var ev = await _context.Events
                               .Include(e => e.Tickets)
                               .FirstOrDefaultAsync(e => e.Id == eventId);
            if (ev == null)
            {
                throw new Exception("Belə tədbir tapılmadı.");
            }

            
            if (ev.Time < DateTime.Now)
            {
                throw new EventExpiredException("Bu tədbirin vaxtı artıq keçib.");
            }
            var ticket = new Ticket
            {
                Price = ev.PriceE,
                EventId = ev.Id
            };

            _context.Tickets.Add(ticket);
            await _context.SaveChangesAsync();
            return ticket;
        }

        public async Task UseTicketAsync(int ticketId)
        {
            var ticket = await _context.Tickets.FindAsync(ticketId);

            if (ticket == null)
                throw new Exception("Belə bilet tapılmadı.");

            if (ticket.IsUsed)
                throw new TicketAlreadyUsedException("Bu bilet artıq istifadə olunub.");

            ticket.IsUsed = true;

            _context.Tickets.Update(ticket);
            await _context.SaveChangesAsync();
        }
    }
}
