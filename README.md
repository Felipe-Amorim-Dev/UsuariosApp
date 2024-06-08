<h1>Aplicação para controle de Usuários</h1>

![.Net](https://img.shields.io/badge/.NET-5C2D91?style=for-the-badge&logo=.net&logoColor=white) ![MicrosoftSQLServer](https://img.shields.io/badge/Microsoft%20SQL%20Server-CC2927?style=for-the-badge&logo=microsoft%20sql%20server&logoColor=white) ![Visual Studio](https://img.shields.io/badge/Visual%20Studio-5C2D91.svg?style=for-the-badge&logo=visual-studio&logoColor=white) ![JWT](https://img.shields.io/badge/JWT-black?style=for-the-badge&logo=JSON%20web%20tokens) ![RabbitMQ](https://img.shields.io/badge/Rabbitmq-FF6600?style=for-the-badge&logo=rabbitmq&logoColor=white)

![image](https://img.shields.io/badge/Feito_em-.NET_CORE-ffbc00)
![image](https://img.shields.io/badge/Version-8-ffbc00)

<p>Esta é uma aplicação construída em .NET Core, utilizando o conceito de Injeção de dependência para controle de Contas de usuários. A aplicação permite realizar a criação do perfil de usuário, alteração dos dados, atualização do email e senha. A forma de autenticação e feita por token, utilizando o JWT (JSON Web Token), a aplicação também utiliza mensageiria para envio de mensagem via email. A integração como banco de dados é feita com o EntityFramework.</p>
<h3><a href="https://github.com/Felipe-Amorim-Dev/ContasWeb">Link do Front-End</a></h3>

<h2>Estrutura do Projeto</h2>

<p>O projeto está dividido em quatro camadas:</p>

<h3>Camada de serviços (Services Layer)</h3>
<p>Nesta camada estão localizadas os controladores (Controllers):</p>

<ul>
<li><h4>UsuariosController</h4>
    Na camada de controle estão os métodos para manipulação das solicitações feitas pelo navegador.
    
    HTTP POST - CriarConta: Método para cadastro de conta de usuários.
    HTTP POST - Autenticar: Método para autenticar usuários já cadastrados.
    HTTP PUT - AtualizarDados: Método para atualização cadastral de usuário.
    HTTP PUT - AtualizarSenha: Método para atualização de senha.
    HTTP PUT - AtualizarEmail: Método para atualização do email.
</li>
</ul>

<h3>Camada de Aplicação (Application Layer)</h3>
<p>Nesta camada estão localizados os modelos e serviços e interfaces(Contratos):</p>


<ul>
<li><h4>Modelos (Models)</h4>

Na models estão os requests e response. É na model que estão as regras de negócio da aplicação, as requisições (Request) são os dados enviados pelo cliente, já o resposta (Response) é o retorno ou a responta que é devolvida para o cliente.

Os modelos estão divididos em:

    CriarConta,
    Autenticar,
    AtualizarDados,
    AtualizarEmail,
    AtualizarSenha.    
</li>

<li><h4>Interfaces(Interfaces/Contracts)</h4>
    
Nas Interfaces estão os métodos para a injeção de dependência da camada de aplicação para a camada de serviços.

IUsuarioAppService os métodos são:

        CriarConta,
        Autenticar, 
        AtualizarDados,
        AtualizarSenha, 
        AtualizarEmail.
    
</li>

<li><h4>Serviço (Services)</h4>
No Serviço estão os métodos para o serviço de comunicação entre o modelo e a camada de Domínio (domain).    

O serviço implementa a interface IUsuarioDomainService, que é uma interface da camada de domínio, gerando seu construtor. 
    
</li>
</ul>

<h3>Camada de Domínio (Domain Layer)</h3>
<p>Nesta camada estão localizados as entidades (Entities), Enums, Helpers, interfaces (interfaces) e serviços (services):</p>


<ul>
<li><h4>Entidade (Entities)</h4>

Na Entidade estão os atributos e métodos Get an Set.

O projeto tem duas entidades, são elas:

    Usuário
        private Guid? _id;
        private string? _nome;
        private string? _sobrenome;
        private string? _email;
        private string? _senha;
        private DateTime? _dataNascimento;
        private string? _sexo;
        private string? _endereco;
        private string? _telefone;
        private byte[]? _fotoPerfil;
        private DateTime? _dataHoraCriacao;
        private DateTime? _dataHoraAlteracao;
        private List<HistoricoAtividadeUsuario>? _historicos;
        private string? _accessToken;

    HistoricoUsuario
        private Guid? _id;
        private DateTime? _dataHora;
        private TipoAtividade? _tipo;
        private string? _descricao;
        private Guid? _usuarioId;
        private Usuario? _usuario;
    
</li>

<li><h4>Enums</h4>
    
No enum estão os valores possíveis para o tipo de histórico de atividade de usuário.

    CRIAÇÃO_DE_USUÁRIO = 1,
    AUTENTICAÇÃO = 2,
    RECUPERAÇÃO_DE_SENHA = 3,
    ATUALIZAÇÃO_DE_DADOS = 4
    
</li>

<li><h4>Helpers</h4>
No helpers ou facilitadores, estão os métodos para criptografia da senha.        
</li>

<li><h4>Interfaces (Interfaces)</h4>
Nas Interfaces estão os métodos para a injeção de dependência da camada de domínio para a camada de aplicação.
</li>

<li><h4>Serviços (Services)</h4>
No serviço estão os métodos para criar, atualizar e retornar. 
</li>
</ul>

<h3>Camada de infraestrutura (Infrastructure)</h3>
<p>Está camada esta dividida em 3 partes, são elas:</p>

    <p>Infra.Data</p>
    <p>Message</p>
    <p>Security</p>

<ul>
<li><h4>Infra.Data</h4>

Na infra estão os métodos para criação das tabelas e conexão com o banco de dados e o repositório com os métodos CRUD.  

<h3>Context</h3>

    Guarda a string de conexão com o banco de dados.

<h3>Mapping</h3>

    Cria as tabelas no banco de dados.

<h3>Repositories</h3>

    Contem os métodos CRUD, para criação, atualização, leitura e remoção.
</li>

<li><h4>Messages</h4>

Na Messages é a parte de mensageiria do projeto, configurado para utilizar o HabbitMQ para o serviço de fila de envio de email.
</li>

<li><h4>Security</h4>

Na Security estão os métodos para configuração e criação do token, utilizando o JWT.
</li>

</ul>

<h2>Como Executar o Projeto</h2>
<p>Para executar o projeto, você deve ter o Visual Studio 2022 devidamente instalado.</p>
<p>O projeto foi desenvolvido em C# .NET CORE versão 8.</p>

<h3>Configuração do Banco</h3>    

<p>Para a Criação do banco de dados foi utilizada a biblioteca do EntityFramework. Deve ser instalado na camada de Data (ProdutoApp.Data) as seguintes bibliotecas:

<ul>
    <li>
    Microsoft.EntityFrameworkCore
    Microsoft.EntityFrameworkCore.SqlServer
    Microsoft.EntityFrameworkCore.Tools
    Microsoft.EntityFrameworkCore.Design
    </li>
</ul>

Deve-se alterar a conection string no Context.

Após instalada as bibliotecas e atualizar a string de conexão devemos usar o console do NuGet para colocar os comandos de criação do Migrations.

    Add-Migration Initial //O initial pode ser qualquer nome.

    Update-Database 
</p>

<h3>Configuração da Mensageiria</h3>
<p>
    Para configurar o envio de mensagem, deve-se alterar algumas configurações no settings.
    <h4>EmailSettings</h4>
    Configurando o email e o provedor de email que vai fazer o envio.
    
        Conta: Deve-se colocar o endereço de email que vai fazer o envio.
        Senha: A senha do email que vai fazer o envio.
        Smtp: O Smtp do provedor de email que vai ser utilizado
        Porta: A porta do provedor de email.

<h4>RabbitMQSettings</h4>
Configuração para conectar ao serviço do RabbitMQ.

    Host: Caminho fornecido pelo RabbitMQ.
    Queue: Nome da fila.

</p>

<h3>Configuração da Security</h3>
<p>
    Não é necessário fazer nem uma alteração para o funcionamento, porem para maior segurança deve ser trocada a chave secreta.
    Para configurar o token, deve-se modificar o TokenSettings:

        SecretKey: Chave secreta para validação do token.
        ExpirationInMinutes: Tempo em minutos para o token expirar.
</p>

<h2>Contribuição</h2>

Contribuições são sempre bem-vindas! Se você encontrou algum problema ou tem alguma sugestão para melhorar este projeto, por favor, abra uma issue ou envie um pull request.

<h3>Licença</h3>

<p>Este projeto é livre(FREE).</p>
