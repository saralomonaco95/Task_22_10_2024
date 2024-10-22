using System.Net.Http.Metrics;
using System.Reflection.Metadata.Ecma335;
using Task_22_10_2024.Models;
using Task_22_10_2024.Repos;

namespace Task_22_10_2024.Services
{
    public class UtenteServices : IserviceLettura<UtenteDTO>, IServiceScrittura<UtenteDTO>

    {

        private readonly UtenteREPO _repo;

        public UtenteServices(UtenteREPO repo) {
        
        _repo = repo;
        
        }



        public bool Aggiorna(UtenteDTO entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<UtenteDTO> CercaTutti()
        {
            throw new NotImplementedException();
        }

        public bool Elimina(string Codice)
        {
            throw new NotImplementedException();
        }

        public bool Inserisci(UtenteDTO entity)
        {
            Utente nuovoUtente = new Utente()
            {
              
               Codice_Utente = entity.Cod is not null ? Guid.NewGuid().ToString().ToUpper() : entity.Cod,
                Nome = entity.Nom,
                Cognome = entity.Cog,
                Email = entity.Ema,
            };
           return _repo.Create(nuovoUtente);
        }



        public UtenteDTO? CercaPerCodice(string codice) 
        {
            UtenteDTO? risultato = null;    

            Utente? utn = _repo.GetbyCodice(codice);
            if (utn is not null) {

                risultato = new UtenteDTO()
                {
                    Cod = utn.Codice_Utente,
                    Nom = utn.Nome,
                    Cog = utn.Cognome,
                    Ema = utn.Email,

                };        
           
            
            }
            return risultato;
        }
    }
}
