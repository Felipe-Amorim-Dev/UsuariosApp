using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsuariosApp.Messages.Settings
{
    public class RabbitMQSettings
    {
        public string Host { get => "amqps://fcddbcgg:sUV7O2x-drZloNHCuF6p2caJc2hk9-ni@shrimp.rmq.cloudamqp.com/fcddbcgg"; }

        public string Queue { get => "mensagem_usuario"; }
    }
}
