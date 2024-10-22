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
            throw new NotImplementedException();
        }

        public IEnumerable<CorsoDTO> CercaTutti()
        {
            throw new NotImplementedException();
        }

        public bool Elimina(string Codice)
        {
            throw new NotImplementedException();
        }

        public bool Inserisci(CorsoDTO entity)
        {
            throw new NotImplementedException();
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
