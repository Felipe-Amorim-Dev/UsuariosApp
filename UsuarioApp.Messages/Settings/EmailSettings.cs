using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsuariosApp.Messages.Settings
{
    public class EmailSettings
    {
        public string? Conta { get => ""; }

        public string? Senha { get => ""; }

        public string? Smtp { get => ""; }

        public int Porta { get => 587; }    
    }
}
