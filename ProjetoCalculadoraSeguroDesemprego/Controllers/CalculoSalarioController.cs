using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjetoCalculadoraSeguroDesemprego.Models;

namespace ProjetoCalculadoraSeguroDesemprego.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalculoSalarioController : ControllerBase
    {
        [HttpPost("calcularSeguroDesemprego")]
        public ActionResult<SeguroDesempregoResponse> CalcularSeguroDesemprego([FromBody] SalarioRequest request)
        {
            if (request.MesesTrabalhados <= 0)
            {
                return BadRequest("Quantidade de meses trabalhados deve ser maior que zero.");
            }

            double mediaSalarial = (request.UltimoSalario + request.PenultimoSalario + request.AntepenultimoSalario) / 3;

            double parcela;
            if (mediaSalarial <= 2041.39)
            {
                parcela = mediaSalarial * 0.8;
                if (parcela <= 1412)
                {
                    parcela = 1412;
                }
            }
            else if (mediaSalarial <= 3402.65)
            {
                parcela = ((mediaSalarial - 2041.39) * 0.5) + 1633.10;
            }
            else
            {
                parcela = 2313.74;
            }

            return Ok(new SeguroDesempregoResponse
            {
                MediaSalarial = mediaSalarial,
                Parcela = parcela
            });
        }
    }
}
