using Domain;
using ServicePattern;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services
{
    interface IServiceCagnotte : IService<Cagnotte>
    {
        IEnumerable<Cagnotte> CagnottesEnCours();
        int MontantCollectee(Cagnotte c);
        int CagnottesParParticipant(Participant p);
        IEnumerable<Entreprise> PlusGrandNbrDeCagnottes(string t);

        Entreprise PlusGrandNbrParticipants();
    }
}
