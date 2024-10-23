using Task_22_10_2024.Models;
using Task_22_10_2024.Repos;

namespace Task_22_10_2024.Services
{
    public class CorsoServices : IserviceLettura<CorsoDTO>, IServiceScrittura<CorsoDTO>
    {

        private readonly CorsoREPO _repo;

        public CorsoServices(CorsoREPO repo)
        {

            _repo = repo;

        }

        public bool Aggiorna(CorsoDTO entity)
        {
            bool risultato = false;

            if (entity.Cod is not null)
            {
                Corso? upCors = _repo.GetbyCodice(entity.Cod);

                if (upCors is not null && entity.Nom is not null && entity.Cod is not null)
                {
                    upCors.Nome = entity.Nom is not null ? entity.Nom : upCors.Nome;
                    upCors.Descrizione = entity.Des is not null ? entity.Des : upCors.Descrizione;
                    upCors.MaxPartecipanti= (int)(entity.MaxP is not null ? entity.MaxP : upCors.MaxPartecipanti);

                    risultato = _repo.Update(upCors);
                };
            }
            return risultato;
        }

        public IEnumerable<CorsoDTO> CercaTutti()
        {
            ICollection<CorsoDTO> risultato = new List<CorsoDTO>();
            IEnumerable<Corso> corsi = _repo.GetAll();
            foreach (Corso c in corsi)
            {
                CorsoDTO temporanea = new CorsoDTO()
                {
                    Cod = c.Codice_Corso,
                    Nom = c.Nome,
                    Des = c.Descrizione,
                    MaxP = c.MaxPartecipanti,

                };
                risultato.Add(temporanea);
            }
            return risultato;
        }

        public bool Elimina(string Codice)
        {
            bool risultato = false;

            Corso? delPac = _repo.GetbyCodice(Codice);
            if (delPac is not null)
            {
                risultato = _repo.Delete(delPac.CorsoID);
            }

            return risultato;
        }

        public bool Inserisci(CorsoDTO entity)
        {
            Corso nuovoCorso = new Corso()
            {
                Codice_Corso = entity.Cod is not null ? Guid.NewGuid().ToString().ToUpper() : entity.Cod,
                Nome = entity.Nom,
                Descrizione = entity.Des,
                MaxPartecipanti = (int)entity.MaxP

            };
            return _repo.Create(nuovoCorso);
        }

        public CorsoDTO? CercaPerCodice(string codice)
        {
            CorsoDTO? risultato = null;

            Corso? utn = _repo.GetbyCodice(codice);
            if (utn is not null)
            {

                risultato = new CorsoDTO()
                {
                   Nom = utn.Nome,
                   Cod = utn.Codice_Corso,
                   Des = utn.Descrizione,
                   Pre = utn.Prezzo,
                   MaxP = utn.MaxPartecipanti,


                };


            }
            return risultato;
        }






    }
}
