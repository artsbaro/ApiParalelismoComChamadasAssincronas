using ApiParalelismoComChamadasAssincronas.Core.Models;
using ApiParalelismoComChamadasAssincronas.Services;
using Microsoft.AspNetCore.Mvc;

namespace ApiParalelismoComChamadasAssincronas.Controllers
{
    [ApiController]
    [Produces("application/json")]
    [Route("[controller]")]
    public class PessoaController : ControllerBase
    {
        private readonly IPessoaService _service;

        private readonly ILogger<PessoaController> _logger;

        public PessoaController(ILogger<PessoaController> logger,
            IPessoaService service)
        {
            _logger = logger;
            _service = service;
        }

        [HttpGet(Name = "Pessoa/{id}")]
        [ProducesResponseType(typeof(Pessoa), StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<Pessoa>>> GetPessoas(int id)
        {
            var pessoa = await _service.GetPessoaAsync(id);
            return Ok(pessoa);
        }
    }
}