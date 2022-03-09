using ApiParalelismoComChamadasAssincronas.Core.Models;
using Flurl.Http;

namespace BffApiParalelismoComChamadasAssincronas.Services.DataService
{
    public class PessoaDataService : DataServiceBase, IPessoaDataService
    {
        public async Task<Pessoa> GetPessoaAsync(int id)
        {
            return await BuildRetryPolicy().ExecuteAsync(() =>
             $"http://localhost:5212/Pessoa?id={id}"
            .WithHeader("accept", "application/json")
            .WithHeader("content-type", "application/json")
            .GetJsonAsync<Pessoa>());
        }
    }
}
