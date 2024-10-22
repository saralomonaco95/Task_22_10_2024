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

        

    }
}
