using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsuariosApp.Domain.Enums;

namespace UsuariosApp.Domain.Entities
{
    public class HistoricoAtividadeUsuario
    {
        #region Atributos
        private Guid? _id;
        private DateTime? _dataHora;
        private TipoAtividade? _tipo;
        private string? _descricao;
        private Guid? _usuarioId;
        private Usuario? _usuario;
        #endregion

        #region Métodos
        public Guid? Id { get => _id; set => _id = value; }
        public DateTime? DataHora { get => _dataHora; set => _dataHora = value; }
        public TipoAtividade? Tipo { get => _tipo; set => _tipo = value; }
        public string? Descricao { get => _descricao; set => _descricao = value; }
        public Guid? UsuarioId { get => _usuarioId; set => _usuarioId = value; }
        public Usuario? Usuario { get => _usuario; set => _usuario = value; }
        #endregion


    }
}
