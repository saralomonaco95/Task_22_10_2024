using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using Task_22_10_2024.Models;

namespace Task_22_10_2024.Context
{  //  3 crei i context 
    public class taskContext :DbContext
    {
        public taskContext(DbContextOptions<taskContext> options) :base(options) { }    


        public DbSet<Utente> Utenti { get; set; }

        public DbSet<Iscrizione> Iscrizioni { get; set; }

        public DbSet<Corso> Corsi { get; set; }


    }
}
