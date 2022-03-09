using ApiParalelismoComChamadasAssincronas.Core.Models;
using BffApiParalelismoComChamadasAssincronas.Services;
using Microsoft.AspNetCore.Mvc;

namespace BffApiParalelismoComChamadasAssincronas.Controllers
{
    [ApiController]
    [Produces("application/json")]
    [Route("[controller]")]
    public class PessoaController : ControllerBase
    {

        private readonly ILogger<PessoaController> _logger;
        private readonly IPessoaService _service;


        public PessoaController(ILogger<PessoaController> logger,
            IPessoaService service)
        {
            _logger = logger;
            _service = service;
        }

        [HttpGet(Name = "Pessoa/{id}")]
        [ProducesResponseType(typeof(IEnumerable<Pessoa>), StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<Pessoa>>> GetPessoaAsync(int id)
        {
            var pessoas = await _service.GetPessoaAsync(id);
            return Ok(pessoas);
        }
    }
}