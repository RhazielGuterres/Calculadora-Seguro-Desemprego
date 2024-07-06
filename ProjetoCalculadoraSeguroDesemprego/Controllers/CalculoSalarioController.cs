using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjetoCalculadoraSeguroDesemprego.Interfaces;
using ProjetoCalculadoraSeguroDesemprego.Models;
using ProjetoCalculadoraSeguroDesemprego.Services;

namespace ProjetoCalculadoraSeguroDesemprego.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalculoSalarioController : ControllerBase
    {
        private readonly ICalculoSeguroDesempregoService _calculoSeguroDesempregoService;

        public CalculoSalarioController(ICalculoSeguroDesempregoService calculoSeguroDesempregoService)
        {
            _calculoSeguroDesempregoService = calculoSeguroDesempregoService;
        }

        [HttpPost("calcularSeguroDesemprego")]
        public IActionResult CalcularSeguroDesemprego([FromBody] SalarioRequest request)
        {
            if (request.MesesTrabalhados <= 0)
            {
                return BadRequest("Quantidade de meses trabalhados deve ser maior que zero.");
            }

            try
            {
                var response = _calculoSeguroDesempregoService.Calcular(request);
                return Ok(response);
            }
            catch (ArgumentException e)
            {
                return BadRequest(e.Message);
            }
        }
    }


}
