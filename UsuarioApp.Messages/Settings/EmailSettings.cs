using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsuariosApp.Messages.Settings
{
    public class EmailSettings
    {
        public string? Conta { get => "usuario.control.app@outlook.com"; }

        public string? Senha { get => "@Qruxasq1"; }

        public string? Smtp { get => "smtp-mail.outlook.com"; }

        public int Porta { get => 587; }    
    }
}
