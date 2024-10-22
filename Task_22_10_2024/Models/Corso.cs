using System.ComponentModel.DataAnnotations.Schema;

namespace Task_22_10_2024.Models
{

    [Table("Corso")]
    public class Corso
    {// crei le classi come primo punto. 1 
        public int CorsoID { get; set; }
        public string Codice_Corso { get; set; } = null!;

        public string Nome { get; set; } = null!;

        public string? Descrizione { get; set; }

        public decimal Prezzo { get; set; }

        public int MaxPartecipanti { get; set; }


       // public virtual ICollection<Iscrizione> Iscrizioni { get; set; } = new List<Iscrizione>();

    }
}
