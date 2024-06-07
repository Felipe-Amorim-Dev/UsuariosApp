using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsuariosApp.Messages.Models
{
    public class UsuarioMessageModel
    {
        public Guid? Id { get; set; }
        public string? To { get; set; }
        public string? Subject { get; set; }
        public string? Body { get; set; }
        public DateTime CriadoEm { get; set; }
    }
}
