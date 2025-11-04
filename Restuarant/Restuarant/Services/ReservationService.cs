using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using Restuarant.Data;
using Restuarant.Exceptions;
using Restuarant.Interfaces;
using Restuarant.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restuarant.Services
{
    internal class ReservationService : IReservationService
    {
        private readonly AppDbContext _context;
        public ReservationService(AppDbContext context)
        {
            _context = context;
        }
        public void CreateReservation(int restaurantId, DateTime date, int tableCount)
        {
            var restaurant = _context.Reservations.Find(restaurantId);
            if (restaurant == null)
            {
                Console.WriteLine("Restoran tapilmadi");
                return;
            }
            if (date < DateTime.Now)
            {
                throw new ReservationExpiredException("Kecmis zaman ola bilmez!!!");
            }
            var reservation = new Reservation
            {
                RestaurantId = restaurantId,
                Date = date,
                TableCount = tableCount
            };

            _context.Reservations.Add(reservation);
        }

        public List<Reservation> GetAllReservation()
        {
            return _context.Reservations.ToList();
        }
        public Reservation GetByIdReservation(int id)
        {
            if (id == null)
            {
                Console.WriteLine("Duzgun daxil edin !!!");
            }

            return _context.Reservations.Find(id);
            
        }

        public List<Reservation> GetPastReservations()
        {
            return _context.Reservations.Where(x => x.Date < DateTime.Now).ToList();
        }

        public void GetPastReservationsUsageReport()
        {
            var reservation = _context.Reservations.Where(x => x.Date < DateTime.Now).ToList();
            int used = reservation.Count(x => x.Used);
            int notused = reservation.Count(x => !x.Used);

            Console.WriteLine($"Kecmis rezervler: {used}/{reservation.Count} istifade olunub.");
        }

        public List<Reservation> GetUpcomingReservations()
        {
            return _context.Reservations.Where(x => x.Date > DateTime.Now).ToList();
        }

        public void UseReservation(int reservationId)
        {
            var reservation = _context.Reservations.Find(reservationId);

            if (reservation == null)
            {
                Console.WriteLine("Rezerv tapılmadı");
                return;
            }

            if (reservation.Used)
            {
                throw new ReservationAlreadyUsedException("Bu rezerv artıq istifadə olunub!");
            }

            if (reservation.Date < DateTime.Now)
            {
                throw new ReservationExpiredException("Keçmiş rezerv istifadə edilə bilməz!");
            }

            reservation.Used = true;
            _context.SaveChanges();
        }
    }
}
