﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsuariosApp.Domain.Enums;

namespace UsuariosApp.Application.Models.CriarConta
{
    public class CriarContaResponseModel
    {
        public Guid? Id { get; set; }                        
        public string? Nome { get; set; }        
        public string? Email { get; set; }                        
        public DateTime? DataHoraCriacao { get; set; }

    }
}
