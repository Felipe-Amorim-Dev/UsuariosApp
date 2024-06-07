using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsuariosApp.Security.Settings
{
    public class TokenSettings
    {
        public static string SecretKey { get => "48A96E0F16B842C08157B68DD1734522"; }        
        public static int ExpirationInMinutes { get => 60; }
    }
}
