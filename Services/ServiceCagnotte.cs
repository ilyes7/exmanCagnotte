using Data.Infrastructure;
using Domain;
using ServicePattern;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Services
{
    class ServiceCagnotte : Service<Cagnotte>, IServiceCagnotte
    {
        public ServiceCagnotte(IUnitOfWork uow) : base(uow)
        {

        }
        public IEnumerable<Cagnotte> CagnottesEnCours()
        {
            return GetMany(c => (c.DateLimite - DateTime.Now).TotalDays > 0).ToList();
        }

        public int CagnottesParParticipant(Participant p)
        {
            IDataBaseFactory dbf = new DataBaseFactory();
            IUnitOfWork uow = new UnitOfWork(dbf);
            ServiceParticipation sp = new ServiceParticipation(uow);
            return sp.GetMany(pa => pa.ParticipantFk == p.ParticipantId).Count();
        }

        public int MontantCollectee(Cagnotte c)
        {
            IDataBaseFactory dbf = new DataBaseFactory();
            IUnitOfWork uow = new UnitOfWork(dbf);
            ServiceParticipation sp = new ServiceParticipation(uow);
            int somme = 0;
            sp.GetMany(p => p.CagnotteFk == c.CagnotteId).Select(p => somme+=p.Montant);
            return somme;
        }

        public IEnumerable<Entreprise> PlusGrandNbrDeCagnottes(string t)
        {
            var id = GetMany(c => c.Type.ToString() == t).GroupBy(c => c.EntrepriseFk).OrderByDescending(c => c.Count()).First().ToString();
            var id1 = GetMany(c => c.Type.ToString() == t).GroupBy(c => c.EntrepriseFk).OrderByDescending(c => c.Count()).Skip(1).First().ToString();
            IList ents = new ArrayList();
            IDataBaseFactory dbf = new DataBaseFactory();
            IUnitOfWork uow = new UnitOfWork(dbf);
            ServiceEntreprise se = new ServiceEntreprise(uow);
            var ent1 = se.GetById(id);
            var ent2 = se.GetById(id1);
            ents.Add(ent1);
            ents.Add(ent2);
            return (IEnumerable<Entreprise>)ents;
        }

        public Entreprise PlusGrandNbrParticipants()
        {
            IDataBaseFactory dbf = new DataBaseFactory();
            IUnitOfWork uow = new UnitOfWork(dbf);
            ServiceEntreprise se = new ServiceEntreprise(uow);
            var cag = GetMany().OrderByDescending(c => c.Participants.Count()).Select(c=> c.CagnotteId).First();
            var ent = GetMany(c => c.CagnotteId == cag).Select(c => c.Entreprise).ToString();
            return se.GetById(ent);

        }
    }
}
