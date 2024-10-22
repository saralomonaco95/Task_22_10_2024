using Task_22_10_2024.Context;
using Task_22_10_2024.Models;

namespace Task_22_10_2024.Repos
{
    public class UtenteREPO : IRepoScrittura<Utente>, IRepoLettura<Utente>
    {

        private readonly taskContext _context;

        public UtenteREPO(taskContext context) { _context = context; }



        public bool Create(Utente entity)
        {
            bool risultato = false;
            try
            {
             _context.Utenti.Add(entity);
                _context.SaveChanges();
               risultato = true;    

            }
            catch(Exception ex)    
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
              Utente ut = _context.Utenti.Single (u => u.UtenteID == id);  
                _context.Utenti.Remove(ut);
                _context.SaveChanges();

                result = true;  

            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);

            }

            return result;  
        }

        public Utente? get(int id)
        {
            return _context.Utenti.Find(id);
        }

        public IEnumerable<Utente> GetAll()
        {
            return _context.Utenti.ToList();
        }

        public bool Update(Utente entity)
        {
            bool result = false;
            try
            {
                Utente ut = _context.Utenti.Single(modifica => modifica.Codice_Utente == entity.Codice_Utente);

                entity.UtenteID = ut.UtenteID;  
                entity.Codice_Utente = entity.Codice_Utente is not null ? entity.Codice_Utente : ut.Codice_Utente;
                entity.Nome = entity.Nome is not null ? entity.Nome : ut.Nome;
                entity.Cognome = entity.Cognome is not null ? entity.Cognome : ut.Cognome;
                entity.Email = entity.Email is not null ? entity.Email : ut.Email;

                _context.Utenti.Add(entity);    
                _context.SaveChanges(); 


            }
            catch( Exception ex ) 
            {
                Console.WriteLine(ex.Message);
            }

            return result;  
        }


        public Utente? GetbyCodice( string codice)
        {
            return _context.Utenti.SingleOrDefault(u => u.Codice_Utente == codice); 
        }
    }
}
