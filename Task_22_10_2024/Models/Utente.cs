using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Task_22_10_2024.Models
{
    [Table("Utente")]
    public class Utente
    {
        [Key]
        public int UtenteID { get; set; }
        public string Codice_Utente { get; set; } = null!;

        public string Nome { get; set; } = null!;
        public string Cognome { get; set; } = null!;

        public string Email { get; set; } = null!;


        // public virtual ICollection<Iscrizione> Iscrizioni { get; set; } = new List<Iscrizione>();






    }
}