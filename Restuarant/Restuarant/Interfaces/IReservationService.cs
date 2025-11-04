using Restuarant.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restuarant.Interfaces
{
    internal interface IReservationService
    {
        void CreateReservation(int restaurantId, DateTime date, int tableCount);
        List<Reservation> GetAllReservation();
        Reservation GetByIdReservation(int id);
        List<Reservation> GetUpcomingReservations();
        List<Reservation> GetPastReservations();
        void GetPastReservationsUsageReport();
        void UseReservation(int reservationId);

    }
}
