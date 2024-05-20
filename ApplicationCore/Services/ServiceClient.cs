using ApplicationCore.Domain;
using ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Services
{
    public class ServiceClient : Service<Client>, IServiceClient
    {
        public ServiceClient(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public double MontantTotal(Client c)
        {
           return c.Reservations.Select(r => r.Pack)
                          .SelectMany(p => p.Activites)
                          .Sum(a => a.Prix);
        }

        public int ReservationsAnnee(Client c)
        {
            return c.Reservations
                    .Where(r => r.DateReservation.Year == DateTime.Now.Year)
                    .Count();
        }
    }
}
