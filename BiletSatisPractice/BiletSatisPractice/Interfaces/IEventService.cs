using BiletSatisPractice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiletSatisPractice.Interfaces
{
    internal interface IEventService
    {
        Task CreateAsync(Event ev);
        Task<List<Event>> GetAllAsync();
        Task<Event> GetByIdAsync(int id);
        Task UpdateAsync(Event ev);
        Task DeleteAsync(int id);
    }
}
