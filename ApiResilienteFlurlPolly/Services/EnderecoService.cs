using ApiParalelismoComChamadasAssincronas.Core.Models;

namespace ApiParalelismoComChamadasAssincronas.Services
{
    public class EnderecoService : IEnderecoService
    {
        public async Task<IEnumerable<Endereco>> GetEnderecosAsync(int pessoaId)
        {
            await Task.Delay(500);

            return Enderecos().Where(e => e.PessoaId == pessoaId);
        }

        private IEnumerable<Endereco> Enderecos()
        {
            return
                new List<Endereco>() {
                new Endereco { Id = 1, PessoaId = 1, TipoEndereco = "Comercial", TipoLogradouro = "Rua", Logradouro = "da Paz", Numero = "S/N", Bairro = "Bela Vista", Cep = "00000000", Cidade = "São Paulo", UF = "SP"},
                new Endereco { Id = 2, PessoaId = 1, TipoEndereco = "Residencial", TipoLogradouro = "AV", Logradouro = "da Guerra", Numero = "380", Bairro = "Vila Prudente", Cep = "00000001", Cidade = "São Paulo", UF = "SP"},
                new Endereco { Id = 3, PessoaId = 2, TipoEndereco = "Comercial", TipoLogradouro = "Rua", Logradouro = "da Paz", Numero = "478", Bairro = "Bela Vista", Cep = "00000002", Cidade = "Salvador", UF = "BA"},
                new Endereco { Id = 4, PessoaId = 2, TipoEndereco = "Residencial", TipoLogradouro = "Avenida", Logradouro = "da Guerra", Numero = "478", Bairro = "Arpoador", Cep = "10000002", Cidade = "Rio de Janeiro", UF = "RJ"},
            };
        }
    }
}
