using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Domain
{
    public class Participation
    {
        public int CagnotteFk { get; set; }

        [ForeignKey("CagnotteFk")]
        public virtual Cagnotte Cagnotte { get; set; }
        public int Montant { get; set; }

        public int ParticipantFk { get; set; }

        [ForeignKey("ParticipantFk")]
        public virtual Participant Participant { get; set; }

    }
}
