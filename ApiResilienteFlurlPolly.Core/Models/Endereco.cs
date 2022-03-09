
namespace ApiParalelismoComChamadasAssincronas.Core.Models
{
    public class Endereco
    {
        public int Id { get; set; }

        public int PessoaId { get; set; }

        public string TipoEndereco { get; set; }

        public string TipoLogradouro { get; set; }

        public string Logradouro { get; set; }

        public string Numero { get; set; }

        public string Cep { get; set; }

        public string Bairro { get; set; }

        public string Cidade { get; set; }

        public string UF { get; set; }

        public string Complemento { get; set; }
    }
}