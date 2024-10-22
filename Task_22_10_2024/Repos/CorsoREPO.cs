using Task_22_10_2024.Context;
using Task_22_10_2024.Models;

namespace Task_22_10_2024.Repos
{
    public class CorsoREPO : IRepoLettura<Corso>, IRepoScrittura<Corso>
    {

        private readonly taskContext _context;

        public CorsoREPO(taskContext context) { _context = context; }


        public bool Create(Corso entity)
        {
            bool risultato = false;
            try
            {
                _context.Corsi.Add(entity);
                _context.SaveChanges();
                risultato = true;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

            }



            return risultato;
        }

        public bool Delete(int id)
        {
            bool result = false;
            try
            {
                Corso cor = _context.Corsi.Single(c => c.CorsoID == id);
                _context.Corsi.Remove(cor);
                _context.SaveChanges();

                result = true;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

            }

            return result;
        }

        public Corso? get(int id)
        {
            return _context.Corsi.Find(id);
        }

        public IEnumerable<Corso> GetAll()
        {
            return _context.Corsi.ToList();
        }

        public bool Update(Corso entity)
        {
            bool result = false;
            try
            {
                Corso cor = _context.Corsi.Single(modifica => modifica.Codice_Corso == entity.Codice_Corso);

                entity.CorsoID = cor.CorsoID;
                entity.Codice_Corso = entity.Codice_Corso is not null ? entity.Codice_Corso : cor.Codice_Corso;
                entity.Nome = entity.Nome is not null ? entity.Nome : cor.Nome;
                entity.Descrizione = entity.Descrizione is not null ? entity.Descrizione : cor.Descrizione;
                entity.Prezzo = entity.Prezzo > 0 ? entity.Prezzo : cor.Prezzo;
                entity.MaxPartecipanti = entity.MaxPartecipanti > 0 ? entity.MaxPartecipanti : cor.MaxPartecipanti;

                _context.Corsi.Add(entity);
                _context.SaveChanges();


            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return result;



        }


        public Corso? GetbyCodice(string codice)
        {
            return _context.Corsi.SingleOrDefault(u => u.Codice_Corso == codice);
        }
    }
}