using Microsoft.AspNetCore.Mvc;
using Task_22_10_2024.Models;
using Task_22_10_2024.Services;

namespace Task_22_10_2024.Controllers
{
    [ApiController]
    [Route("api/Utente")]
    public class UtenteController : Controller
    {
        // ignietto services nel controller 
        private readonly UtenteServices _services;

        public UtenteController(UtenteServices services) {
        
         _services = services;
        }

        //-----------      --------------- ---------- 
        [HttpGet("{VarCodice}")]
        public ActionResult<UtenteDTO?> VisualizzaUtente(string VarCodice)
        {
            if(string.IsNullOrWhiteSpace(VarCodice))
                return BadRequest();


            UtenteDTO? utente = _services.CercaPerCodice(VarCodice);   
            if (utente is not null) { 
            return Ok(utente);
                   }

            return NotFound();  

        }

        [HttpGet]
        public ActionResult<IEnumerable<UtenteDTO>> ListaPacchetti()
        {
            return Ok(_services.CercaTutti());
        }




        [HttpPost]

        public IActionResult InserisciUtente(UtenteDTO utente) {
            if (string.IsNullOrWhiteSpace(utente.Nom)
                || string.IsNullOrWhiteSpace(utente.Cog) 
                || string.IsNullOrWhiteSpace(utente.Ema))

                return BadRequest();


            if (_services.Inserisci(utente))
                return Ok();

            return BadRequest();    
            
        }

        [HttpPut("{varCodice}")]
        public IActionResult AgiornaUtente(string varCodice,UtenteDTO utDto)
        {
            if(string.IsNullOrWhiteSpace(varCodice)||
                    string.IsNullOrWhiteSpace(utDto.Nom) ||
                    string.IsNullOrWhiteSpace(utDto.Cog))
                    return BadRequest();
            utDto.Cod = varCodice;  

            if(_services.Aggiorna(utDto))
                return Ok();
            return BadRequest();        
        }


        [HttpDelete]
        public IActionResult EliminaUtente(string varCodice)
        {
            if (string.IsNullOrWhiteSpace(varCodice))
                return BadRequest();

            if (_services.Elimina(varCodice))
                return Ok();

            return BadRequest();
        }


    }
}
