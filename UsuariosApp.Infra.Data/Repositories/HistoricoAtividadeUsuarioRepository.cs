using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsuariosApp.Domain.Entities;
using UsuariosApp.Domain.Interfaces.Repositories;
using UsuariosApp.Infra.Data.Contexts;

namespace UsuariosApp.Infra.Data.Repositories
{
    public class HistoricoAtividadeUsuarioRepository : BaseRepository<HistoricoAtividadeUsuario>, IHistoricoUsuarioRepository
    {
        public List<HistoricoAtividadeUsuario> Get(Guid usuarioId)
        {
            using (var dataContext = new DataContext())
            {
                return dataContext.HistoricoAtividadeUsuario.Where(h => h.UsuarioId.Equals(usuarioId))
                    .OrderByDescending(h => h.DataHora).ToList();

            }
        }
    }
}
