
namespace ApiParalelismoComChamadasAssincronas.Core.Models
{
    public class Pessoa
    {
        
        public int Id { get; set; }

        
        public string Nome { get; set; }

        
        public DateTime DataNascimento { get; set; }


        public IEnumerable<Endereco> Enderecos { get; set; }

    }
}