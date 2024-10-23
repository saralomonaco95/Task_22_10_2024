using Microsoft.AspNetCore.Http.HttpResults;
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
            bool risultato = false;

            if (entity.Cod is not null)
            {
                Utente? upUt = _repo.GetbyCodice(entity.Cod);

                if (upUt is not null && entity.Nom is not null && entity.Nom is not null)
                {
                    upUt.Nome = entity.Nom is not null ? entity.Nom : upUt.Nome;
                    upUt.Cognome = entity.Cog is not null ? entity.Cog : upUt.Cognome;
                    upUt.Email = entity.Ema is not null ? entity.Ema : upUt.Email;

                    risultato = _repo.Update(upUt);
                };
            }
            return risultato;
        }

        public IEnumerable<UtenteDTO> CercaTutti()
        {
            ICollection<UtenteDTO> risultato = new List<UtenteDTO>();
            IEnumerable<Utente> utenti = _repo.GetAll();
            foreach (Utente p in utenti)
            {
                UtenteDTO temporanea = new UtenteDTO()
                {
                    Cod = p.Codice_Utente,
                    Nom = p.Nome,
                    Cog = p.Cognome,
                    Ema = p.Email,

                };
                risultato.Add(temporanea);
            }
            return risultato;


        }

        public bool Elimina(string Codice)
        {
            bool risultato = false;

            Utente? delPac = _repo.GetbyCodice(Codice);
            if (delPac is not null)
            {
                risultato = _repo.Delete(delPac.UtenteID);
            }

            return risultato;
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
