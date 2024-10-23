using Microsoft.AspNetCore.Mvc;
using Task_22_10_2024.Models;
using Task_22_10_2024.Services;

namespace Task_22_10_2024.Controllers
{
    [ApiController]
    [Route("api/Corsi")]
    public class CorsoController : Controller
    {

        private readonly CorsoServices _services;

        public CorsoController(CorsoServices services)
        {

            _services = services;
        }


        [HttpGet("{VarCodice}")]
        public ActionResult<CorsoDTO?> VisualizzaCorso(string VarCodice)
        {
            if (string.IsNullOrWhiteSpace(VarCodice))
                return BadRequest();


            CorsoDTO? corso = _services.CercaPerCodice(VarCodice);
            if (corso is not null)
            {
                return Ok(corso);
            }

            return NotFound();

        }

        [HttpGet]
        public ActionResult<IEnumerable<CorsoDTO>> ListaPacchetti()
        {

            return Ok(_services.CercaTutti());
        }

        [HttpPost]
        public IActionResult InserimentoCorso(CorsoDTO obj)
        {
            if (string.IsNullOrWhiteSpace(obj.Nom) || obj.MaxP == 20)
                return BadRequest();


            if (_services.Inserisci(obj))
                return Ok();

            return BadRequest();
        }

        [HttpDelete]
        public IActionResult EliminaCorso(string varCodice)
        {
            if (string.IsNullOrWhiteSpace(varCodice))
                return BadRequest();

            if (_services.Elimina(varCodice))
                return Ok();

            return BadRequest();
        }

        [HttpPut("{varCodice}")]
        public IActionResult AggiornaCorso(string varCodice, CorsoDTO corDto)
        {
            if (string.IsNullOrWhiteSpace(varCodice) ||
                string.IsNullOrWhiteSpace(corDto.Nom))
                return BadRequest();

            corDto.Cod = varCodice;

            if (_services.Aggiorna(corDto))
                return Ok();

            return BadRequest();
        }





    }
}
