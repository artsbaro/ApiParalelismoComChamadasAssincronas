using ApiParalelismoComChamadasAssincronas.Core.Models;

namespace BffApiParalelismoComChamadasAssincronas.Services.DataService
{
    public interface IPessoaDataService
    {
        Task<Pessoa> GetPessoaAsync(int id);
    }
}
