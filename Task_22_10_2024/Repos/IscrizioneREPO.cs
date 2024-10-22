using Task_22_10_2024.Context;
using Task_22_10_2024.Models;

namespace Task_22_10_2024.Repos
{
    public class IscrizioneREPO : IRepoLettura<Iscrizione>, IRepoScrittura<Iscrizione>
    {

        private readonly taskContext _context;

        public IscrizioneREPO(taskContext context) { _context = context; }




        public bool Create(Iscrizione entity)
        {
            bool risultato = false;
            try
            {
                _context.Iscrizioni.Add(entity);
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
                Iscrizione isc = _context.Iscrizioni.Single(i => i.IscrizioneID == id);
                _context.Iscrizioni.Remove(isc);
                _context.SaveChanges();

                result = true;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

            }

            return result;
        }

        public Iscrizione? get(int id)
        {
            return _context.Iscrizioni.Find(id);
        }

        public IEnumerable<Iscrizione> GetAll()
        {
            return _context.Iscrizioni.ToList();
        }

        public bool Update(Iscrizione entity)
        {
           bool result =false;
            try
            {
                Iscrizione isc = _context.Iscrizioni.Single(modifica =>modifica.IscrizioneID == entity.IscrizioneID);

                entity.IscrizioneID = isc.IscrizioneID;

                entity.Data_Iscrizione =entity.Data_Iscrizione = true? entity.Data_Iscrizione :isc.Data_Iscrizione;

                entity.UtenteRIF = isc.UtenteRIF;
                entity.CorsoRIF = isc.CorsoRIF; 


               _context.Iscrizioni.Add(entity);
                _context.SaveChanges(); 

                result = true;  

            }
            catch (Exception ex) {
            
            
            Console.WriteLine(ex.Message);  
            
            
            
            
            }






            return result;  
        }
    }
}
