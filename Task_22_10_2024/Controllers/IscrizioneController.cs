using Microsoft.AspNetCore.Mvc;
using Task_22_10_2024.Services;

namespace Task_22_10_2024.Controllers
{
    [ApiController]
    [Route("api/Iscrizioni")]
    public class IscrizioneController : Controller
    {
        private readonly IscrizioneServices _services;

        public IscrizioneController(IscrizioneServices services)
        {

            _services = services;
        }
    }
}
