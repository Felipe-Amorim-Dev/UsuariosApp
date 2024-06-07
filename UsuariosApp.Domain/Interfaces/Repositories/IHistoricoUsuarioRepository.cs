using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsuariosApp.Domain.Entities;

namespace UsuariosApp.Domain.Interfaces.Repositories
{
    public interface IHistoricoUsuarioRepository : IBaseRepository<HistoricoAtividadeUsuario>
    {
        List<HistoricoAtividadeUsuario> Get(Guid usuarioId);
    }
}
