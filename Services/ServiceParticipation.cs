using Data.Infrastructure;
using Domain;
using ServicePattern;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services
{
    class ServiceParticipation : Service<Participation>, IServiceParticipation
    {
        public ServiceParticipation(IUnitOfWork uow) : base(uow)
        {

        }
    }
}
