using ApplicationCore.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Interfaces
{
    public interface IServiceClient:IService<Client>
    {
        double MontantTotal(Client c);
        int ReservationsAnnee(Client c);
    }
}
