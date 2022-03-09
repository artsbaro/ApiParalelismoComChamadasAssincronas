using ApiParalelismoComChamadasAssincronas.Core.Models;
using ApiParalelismoComChamadasAssincronas.Services;
using Microsoft.AspNetCore.Mvc;

namespace ApiParalelismoComChamadasAssincronas.Controllers
{
    [ApiController]
    [Produces("application/json")]
    [Route("[controller]")]
    public class EnderecoController : ControllerBase
    {
        private readonly IEnderecoService _service;

        private readonly ILogger<EnderecoController> _logger;

        public EnderecoController(ILogger<EnderecoController> logger,
            IEnderecoService service)
        {
            _logger = logger;
            _service = service;
        }

        [HttpGet(Name = "Enderecos/{pessoaId}")]
        [ProducesResponseType(typeof(IEnumerable<Endereco>), StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<Endereco>>> GetEnderecosAsync(int pessoaId)
        {
            var endereco = await _service.GetEnderecosAsync(pessoaId);
            return Ok(endereco);
        }
    }
}