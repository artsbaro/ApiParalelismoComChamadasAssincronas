using ApiParalelismoComChamadasAssincronas.Core.Models;

namespace ApiParalelismoComChamadasAssincronas.Services
{
    public interface IPessoaService
    {
        Task<Pessoa> GetPessoaAsync(int id);
    }
}
