using ApiParalelismoComChamadasAssincronas.Core.Models;
using BffApiParalelismoComChamadasAssincronas.Services.DataService;

namespace BffApiParalelismoComChamadasAssincronas.Services
{
    public class PessoaService : IPessoaService
    {
        readonly IPessoaDataService _pessoaDataService;
        readonly IEnderecoDataService _enderecoDataService;

        public PessoaService(IPessoaDataService pessoaDataService,
            IEnderecoDataService enderecoDataService)
        {
            _pessoaDataService = pessoaDataService;
            _enderecoDataService = enderecoDataService;
        }

        public async Task<Pessoa> GetPessoaAsync(int id)
        {
            var pessoa = await _pessoaDataService.GetPessoaAsync(id);

            if (pessoa != null)
                pessoa.Enderecos = await _enderecoDataService.GetEnderecosAsync(idPessoa: id);

            return pessoa;
        }

        // Com paralelismo

        public async Task<Pessoa> GetPessoaComParalelismoAsync(int id)
        {
            Pessoa pessoa = new Pessoa();
            IEnumerable<Endereco> enderecos = Enumerable.Empty<Endereco>();

            var tasks = new Task[] {

               Task.Run( async () => pessoa = await _pessoaDataService.GetPessoaAsync(id)),
               Task.Run( async () => enderecos = await _enderecoDataService.GetEnderecosAsync(id))
            };
            Task.WaitAll(tasks);

            if (pessoa.Id > 0)
                pessoa.Enderecos = enderecos;

            return pessoa;
        }
    }
}
