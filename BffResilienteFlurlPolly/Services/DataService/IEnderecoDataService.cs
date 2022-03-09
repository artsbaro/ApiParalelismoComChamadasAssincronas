using ApiParalelismoComChamadasAssincronas.Core.Models;

namespace BffApiParalelismoComChamadasAssincronas.Services.DataService
{
    public interface IEnderecoDataService
    {
        Task<IEnumerable<Endereco>> GetEnderecosAsync(int idPessoa);
    }
}
