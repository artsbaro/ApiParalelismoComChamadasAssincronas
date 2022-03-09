using ApiParalelismoComChamadasAssincronas.Core.Models;

namespace ApiParalelismoComChamadasAssincronas.Services
{
    public interface IEnderecoService
    {
        Task<IEnumerable<Endereco>> GetEnderecosAsync(int pessoaId);
    }
}
