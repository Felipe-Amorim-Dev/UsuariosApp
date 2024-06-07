using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsuariosApp.Domain.Enums;

namespace UsuariosApp.Domain.Entities
{
    public class Usuario
    {
        #region Atributos
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
        #endregion

        #region Métodos
        public Guid? Id { get => _id; set => _id = value; }
        public string? Nome { get => _nome; set => _nome = value; }
        public string? Sobrenome { get => _sobrenome; set => _sobrenome = value; }
        public string? Email { get => _email; set => _email = value; }
        public string? Senha { get => _senha; set => _senha = value; }
        public DateTime? DataNascimento { get => _dataNascimento; set => _dataNascimento = value; }
        public string? Sexo { get => _sexo; set => _sexo = value; }
        public string? Endereco { get => _endereco; set => _endereco = value; }
        public string? Telefone { get => _telefone; set => _telefone = value; }
        public byte[]? FotoPerfil { get => _fotoPerfil; set => _fotoPerfil = value; }
        public DateTime? DataHoraCriacao { get => _dataHoraCriacao; set => _dataHoraCriacao = value; }
        public DateTime? DataHoraAlteracao { get => _dataHoraAlteracao; set => _dataHoraAlteracao = value; }
        public List<HistoricoAtividadeUsuario>? Historicos { get => _historicos; set => _historicos = value; }
        public string? AccessToken { get => _accessToken; set => _accessToken = value; }
        #endregion

    }
}
