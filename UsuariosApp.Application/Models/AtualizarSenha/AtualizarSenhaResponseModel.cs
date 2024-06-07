﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsuariosApp.Application.Models.AtualizarSenha
{
    public class AtualizarSenhaResponseModel
    {
        public Guid? Id { get; set; }
        public string? Email { get; set; }
        public string? Nome { get; set; }
        public DateTime? DataHoraAlteracao { get; set; }
    }
}
