using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Domain
{
    public enum Type
    {
        CadeauCommun = 0,
        DepenseaPlusieur = 1,
        ProjetSolidaire = 2,
        Autres = 3
    };
    public class Cagnotte
    {
        public int CagnotteId { get; set; }
        [DataType(DataType.Date)]
        public DateTime DateLimite { get; set; }
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        public string Photo { get; set; }
        [Range(0, int.MaxValue)]
        public int SommeDemendee { get; set; }
        [Required(ErrorMessage = "name is required")]
        public string Titre { get; set; }
        public Type Type { get; set; } = 0;
        public virtual List<Participant> Participants { get; set; }
        public int EntrepriseFk { get; set; }

        [ForeignKey("EntrepriseFk")]
        public virtual Entreprise Entreprise { get; set; }

    }
}
