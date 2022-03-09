using ApiParalelismoComChamadasAssincronas.Core.Models;
using Flurl.Http;

namespace BffApiParalelismoComChamadasAssincronas.Services.DataService
{
    public class EnderecoDataService : DataServiceBase, IEnderecoDataService
    {
        public async Task<IEnumerable<Endereco>> GetEnderecosAsync(int idPessoa)
        {
            return await BuildRetryPolicy().ExecuteAsync(() =>
                 $"http://localhost:5212/Endereco?pessoaId={idPessoa}"
                .WithHeader("accept", "application/json")
                .WithHeader("content-type", "application/json")
                .GetJsonAsync<IEnumerable<Endereco>>());
        }
    }
}
