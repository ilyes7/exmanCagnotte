using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class Participant
    {
        public string MailParticipant { get; set; }
        public string Nom { get; set; }
        public int ParticipantId { get; set; }
        public string Prenom { get; set; }
        public virtual List<Cagnotte> Cagnottes { get; set; }
    }
}
