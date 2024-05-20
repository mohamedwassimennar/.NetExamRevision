using ApplicationCore.Domain;
using ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Services
{
    public class ServiceReservation : Service<Reservation>, IServiceReservation
    {
        public ServiceReservation(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public IEnumerable<IGrouping<Client, Reservation>> GroupedReservations()
        {
          return  GetMany(r => (DateTime.Now - r.DateReservation).TotalDays < 7
            && (DateTime.Now - r.DateReservation).TotalDays > 0)
                .GroupBy(r => r.Client);
        }
    }
}
