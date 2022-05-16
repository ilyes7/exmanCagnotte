
using Data.Infrastructure;
using Domain;
using ServicePattern;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services
{
    class ServiceEntreprise : Service<Entreprise>, IserviceEntreprise
    {
        public ServiceEntreprise(IUnitOfWork uow) : base(uow)
        {

        }
    }
}
