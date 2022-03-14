# ApiParalelismoComChamadasAssincronas
Pequeno projeto que mostra como aplicar paralelismo em processos afim de obter performance em projetos .Net 6.

## Com Paralelismo
Utilizando paralelismo em suas chamadas a um servico que consome uma http
>> Ex.
```C#
        public async Task<Pessoa> GetPessoaAsync(int id)
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
```                

## Sem paralelismo
```C#
        public async Task<Pessoa> GetPessoaAsync(int id)
        {
            var pessoa = await _pessoaDataService.GetPessoaAsync(id);

            if (pessoa != null)
                pessoa.Enderecos = await _enderecoDataService.GetEnderecosAsync(idPessoa: id);

            return pessoa;
        }
```

A api que esse projeto consome é uma bem simples que possui dois EndPoints.
##### 1 para consulta de pessoa
##### 1 para consulta de endereços da pessoa pelo campo IdPessoa

O ideal seria termos dois projetos, 1 para cada api(Enderecos e Pessoa), já que se a mesma API irá retornar a pessoa e ela mesma pode retornar os endereços, seria melhor ela já retornar a pessoa com os endereços preenchidos. Porém, esse não é o objetivo da solução apresentada. O objetivo é mostrar como a utilização de paralelismo pode trazer grande ganho de performace para sua aplicação.

Nesse contexto, para fins de simulaçao de um cenário lento na aplicação, coloquei um Task.Delay para cada consulta.
##### Api Pessoa 300 milisegundos
##### Api Endereços 500 milisegundos

```C#
        public async Task<Pessoa> GetPessoaAsync(int id)
        {
            await Task.Delay(300);
            return GetPessoas().FirstOrDefault(p => p.Id == id);
        }

        private IEnumerable<Pessoa> GetPessoas()
        {
            return new List<Pessoa>() {
                new Pessoa { Id = 1, Nome = "Antonio", DataNascimento = new DateTime(1983, 6, 15)},
                new Pessoa { Id = 2, Nome = "João", DataNascimento = new DateTime(1988, 12, 12)},
                new Pessoa { Id = 3, Nome = "Pedro", DataNascimento = new DateTime(1983, 6, 15)},
                new Pessoa { Id = 4, Nome = "Maria", DataNascimento = new DateTime(1990, 2, 12)},
            };
        }
```


```C#
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
```        

Resultados:

Sem paralelismo
Chamada 1 - 874 ms
Chamada 2 - 842 ms
Chamada 3 - 830 ms

Com paralelismo
Chamada 1 - 528 ms
Chamada 2 - 556 ms
Chamada 3 - 534 ms

Para testar as chamadas utilizei o Postman.
No Visual Studio, ou VS Code, reomva o comentário conforme o cenário de teste que deseja e veja os resultados.


```C#

        [HttpGet(Name = "Pessoa/{id}")]
        [ProducesResponseType(typeof(Pessoa), StatusCodes.Status200OK)]
        public async Task<ActionResult<Pessoa>> GetPessoaAsync(int id)
        {
            //var pessoa = await _service.GetPessoaAsync(id);
            var pessoa = await _service.GetPessoaComParalelismoAsync(id);

            return Ok(pessoa);
        }

```    

