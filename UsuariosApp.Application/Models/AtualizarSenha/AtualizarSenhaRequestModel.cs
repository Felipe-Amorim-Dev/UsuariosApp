using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsuariosApp.Application.Models.AtualizarSenha
{
    public class AtualizarSenhaRequestModel
    {
        public string? Email { get; set; }
        public string? Senha { get; set; }
        public string? SenhaConfirmacao { get; set; }
    }
}
