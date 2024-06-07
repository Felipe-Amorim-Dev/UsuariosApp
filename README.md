<h1>Aplicação para gerenciamento Financeiro</h1>

![.Net](https://img.shields.io/badge/.NET-5C2D91?style=for-the-badge&logo=.net&logoColor=white) ![MicrosoftSQLServer](https://img.shields.io/badge/Microsoft%20SQL%20Server-CC2927?style=for-the-badge&logo=microsoft%20sql%20server&logoColor=white) ![Visual Studio](https://img.shields.io/badge/Visual%20Studio-5C2D91.svg?style=for-the-badge&logo=visual-studio&logoColor=white)

![image](https://img.shields.io/badge/Feito_em-.NET_CORE-ffbc00)
![image](https://img.shields.io/badge/Version-8-ffbc00)

<p>Esta é uma aplicação construída em .NET Core para gerenciamento de Contas a pagar e receber. A aplicação permite realizar operações CRUD (Criar, Ler, Atualizar, Deletar) em uma base de dados CONTAS utilizando o DAPPER para interação com o banco de dados.</p>
<h3><a href="https://github.com/Felipe-Amorim-Dev/ContasWeb">Link do Front-End</a></h3>

<h2>Estrutura do Projeto</h2>

<p>O projeto está dividido em duas camadas:</p>

<h3>Camada de serviços (Services Layer)</h3>
<p>Nesta camada estão localizadas os controladores (Controllers) e os modelos (Models):</p>

<ul>
<li><h4>ProdutosController</h4>
    Na camada de controle estão os métodos para manipulação das solicitações feitas pelo navegador.
    
    HTTP POST - CadastrarConta: Método para cadastro de conta.
    HTTP PUT - AtualizarConta: Método para atualizar a conta.
    HTTP DELETE - RemoverConta: Método para exclusção de conta.
    HTTP GET - ConsultarConta: Método para consultar todas as contas.    
</li>

<li><h4>Models</h4>
    Na camada de modelo estão os dados da aplicação onde são aplicadas validações para aplicar as regras de negócio.

    ContaPostModel - modelo para validação dos dados: Nome, DataHoraCriacao, Valor, Tipo, Observacao e Categoria.
    ContaPutModel - modelo para validação dos dados: Id, Nome, DataHoraCriacao, Valor, Tipo, Observacao e Categoria.
    ContaGetModel - modelo para retorno dos dados: Id, Nome, DataHoraCriacao, Valor, Tipo, Observacao e Categoria.
</li>
</ul>

<h3>Camada de dados (Data Layer)</h3>
<p>Nesta camada estão localizado as Entities (Entidades), o Repositories (Repositórios), a Settings(Configuração) e os Enums:</p>


<ul>
<li><h4>Entities Conta</h4>

Na Entidade se encontra os atributos usando o conceito de encapsulamento e métodos Get e Set.

Os atributos da conta são:

    Private Guid? _id;
    private string? _nome;
    private DateTime? _dataHoraCriacao;
    private decimal? _valor;
    private TipoConta? _tipo;
    private string? _observacao;
    private Categorias? _categoria;
    
Os métodos da conta são:

    public Guid? Id { get => _id; set => _id = value; }
    public string? Nome { get => _nome; set => _nome = value; }
    public DateTime? DataCriacao { get => _dataCriacao; set => _dataCriacao = value; }
    public decimal? Valor { get => _valor; set => _valor = value; }
    public TipoConta? Tipo { get => _tipo; set => _tipo = value; }
    public string? Observacao { get => _observacao; set => _observacao = value; }        
    public Categorias? Categoria { get => _categoria; set => _categoria = value; }  
</li>

<li><h4>Enums</h4>
    Enums representão um conjunto de código fixos de valores.

    No Projeto existem dois Enums, TipoConta e Categorias.    
</li>

<li><h4>ContaRepository</h4>
    Na camada de Repositorio estão as implementações das operações de CRUD, que usa comandos SQL, que através do SqlServerSettings acessa o banco de dados.    

Operações: 

        ADD, UPDATE, DELETE, GetALL e GetById
    
</li>

<li><h4>SqlServerSettings</h4>
    Na camada settings cria o método para conexção com o banco de dados atraves da connection String.
    
</li>
</ul>


<h2>Como Executar o Projeto</h2>
<p>Para executar o projeto, você deve ter o Visual Studio 2022 devidamente instalado.</p>
<p>O projeto foi desenvolvido em C# .NET CORE versão 8.</p>
<p>
Para a Criação do banco de dados foi utilizada a blibioteca do DAPPER.
Deve ser instalado na camada de Data (ContasApp.Data) as seguintes blibiotecas:
<ul>
<li>
DAPPER
</li>
<li>
System.Data.SqlClient
</li>
</ul>
</p>

Depois de instalada as blibiotecas devemos criar as tabelas no banco de dados:

SCRIPT SQL:

    CREATE TABLE CONTA (
    ID		        UNIQUEIDENTIFIER					NOT NULL,
    NOME			NVARCHAR(200)						NOT NULL,
    DATACRIACAO	        DATE							NOT NULL,
    TIPO			NVARCHAR(100)						NOT NULL,
    VALOR			DECIMAL(18,2)						NOT NULL,
    OBSERVACAO		NVARCHAR(500)						NULL,
    CATEGORIA		NVARCHAR(100)						NOT NULL,
    PRIMARY KEY(ID))
    GO


<h2>Contribuição</h2>

Contribuições são sempre bem-vindas! Se você encontrou algum problema ou tem alguma sugestão para melhorar este projeto, por favor, abra uma issue ou envie um pull request.

<h3>Licença</h3>

<p>Este projeto é livre(FREE).</p>
