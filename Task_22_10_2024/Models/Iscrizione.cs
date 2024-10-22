using Microsoft.AspNetCore.Http.HttpResults;
using System.ComponentModel.DataAnnotations.Schema;

namespace Task_22_10_2024.Models
{
    [Table("Iscrizione")]
    public class Iscrizione
    {
        public int IscrizioneID { get; set; }
        public DateOnly Data_Iscrizione { get; set; }
        public int UtenteRIF { get; set; }
        public int CorsoRIF { get; set; }
     

       // public virtual Corso CorsoRifNavigation { get; set; } = null!;

      //  public virtual Utente UtenteRifNavigation { get; set; } = null!;

    }
}


