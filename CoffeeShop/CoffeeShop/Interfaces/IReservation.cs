using CoffeeShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoffeeShop.Interfaces
{
    public interface IReservation
    {
        List<Reservation> GetReservations();
        Task<Reservation> AddReservation(Reservation reservation);
    }
}
