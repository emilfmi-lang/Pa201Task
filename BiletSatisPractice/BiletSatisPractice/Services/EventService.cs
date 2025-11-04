using BiletSatisPractice.Data;
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
    internal class EventService : IEventService
    {

        private readonly TicketDbContext _context;

        public EventService(TicketDbContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(Event ev)
        {
            if (ev == null)
            {
                Console.WriteLine("Bos qoyula bilmez");
                return;
            }
            await _context.Events.AddAsync(ev);
            await _context.SaveChangesAsync();
            Console.WriteLine("Event elave olundu:" + ev.Name);
        }

        public async Task DeleteAsync(int id)
        {
            var evnt = await _context.Events.FindAsync(id);
            if (evnt != null)
            {
                _context.Events.Remove(evnt);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<Event>> GetAllAsync()
        {
            return await _context.Events
                             .Include(e => e.Tickets)
                             .ToListAsync();
        }

        public async Task<Event> GetByIdAsync(int id)
        {
            return await _context.Events
                                 .Include(e => e.Tickets)
                                 .FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task UpdateAsync(Event ev)
        {
            _context.Events.Update(ev);
            await _context.SaveChangesAsync();
        }
    }
}
