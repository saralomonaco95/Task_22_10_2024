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







    }
}
