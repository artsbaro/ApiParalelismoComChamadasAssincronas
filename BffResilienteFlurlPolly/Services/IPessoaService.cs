using ApiParalelismoComChamadasAssincronas.Core.Models;

namespace BffApiParalelismoComChamadasAssincronas.Services
{
    public interface IPessoaService
    {
        Task<Pessoa> GetPessoaAsync(int id);
        Task<Pessoa> GetPessoaComParalelismoAsync(int id);
    }
}
