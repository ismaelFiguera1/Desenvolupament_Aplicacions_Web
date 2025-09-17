using Microsoft.AspNetCore.Mvc;
using API_Cronometre.Services;
using API_Cronometre;

namespace API_Cronometre.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CronometreController : ControllerBase
    {
        private readonly CronometreService _servei;

        public CronometreController(CronometreService servei)
        {
            _servei = servei;
        }

        [HttpPost("{id}/iniciar")]
        public IActionResult IniciarPorId(Guid id)
        {
            bool iniciat = _servei.IniciarCronometre(id);

            if (iniciat)
            {
                return Ok($"Cronòmetre {id} iniciat.");
            }
            else
            {
                return NotFound($"No s'ha trobat cap cronòmetre amb ID {id}");
            }

            
        }





        [HttpGet("llistar")]
        public ActionResult<Cronometre> Llistar()
        {
            List<Cronometre> llistaCronometres = _servei.ObtenirCronometres();
            return Ok(llistaCronometres);
        }




        [HttpGet("{id}/get")]
        public ActionResult<Cronometre> Get(Guid id)
        {
            Cronometre? resultat = _servei.EstatCronometre(id);

            if (resultat == null)
            {
                return NotFound($"No s'ha trobat cap cronòmetre amb ID {id}");
            }

            return Ok(resultat);
        }





        [HttpPost("{id}/pause")]
        public IActionResult Pausar(Guid id)
        {
            double? segons = _servei.PausarCronometre(id);

            if (segons == null)
            {
                return BadRequest($"No s'ha pogut pausar el cronòmetre amb ID {id}.");
            }

            return Ok($"Cronòmetre {id} pausat. Segons acumulats: {segons:F2}");
        }



        [HttpGet("{id}/status")]
        public IActionResult ObtenirStatus(Guid id)
        {
            string? estat = _servei.ObtenirEstat(id);

            if (estat == null)
            {
                return NotFound($"No s'ha trobat cap cronòmetre amb ID {id}");
            }

            return Ok($"Estat del cronòmetre {id}: {estat}");
        }




        [HttpPost("{id}/resume")]
        public IActionResult Reprendre(Guid id)
        {
            double? segons = _servei.Resume(id);

            if (segons == null)
            {
                return BadRequest($"No s'ha pogut continuar el cronometre amb ID {id}. ");
            }

            return Ok($"Cronòmetre {id} continuat.");
        }


        [HttpPost("{id}/stop")]
        public IActionResult Stop(Guid id)
        {
            double? segons = _servei.STOPCronometre(id);

            if (segons == null)
            {
                return NotFound($"No s'ha trobat cap cronòmetre amb ID {id}");
            }

            return  Ok(new
            {
                Id = id,
                Missatge = "Cronometre aturat i eliminat.",
                Segons = segons
            });
        }


        [HttpPost("CrearIniciar")]
        public IActionResult CrearIniciar()
        {
            Guid id = _servei.CrearINiciarCronometre();

            Cronometre? nou = _servei.EstatCronometre(id);

            if (nou == null)
            {
                return StatusCode(500, "Error al crear el cronòmetre.");
            }

            return Ok(new
            {
                Missatge = "Cronòmetre creat i iniciat correctament",
                Id = nou.Id.ToString(),
                Nom = nou.Name
            });
        }



    }
}
