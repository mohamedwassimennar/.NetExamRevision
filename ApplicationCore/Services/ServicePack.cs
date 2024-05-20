using ApplicationCore.Domain;
using ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Services
{
    public class ServicePack : Service<Pack>, IServicePack
    {
        public ServicePack(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public double PourcentagePacksLongs()
        {
            return (GetMany(p=>p.Duree>7).Count()/ GetMany().Count())*100;
        }

        public double PrixPack(Pack p)
        {
          return  p.Activites.Sum(a=>a.Prix);
        }
    }
}
