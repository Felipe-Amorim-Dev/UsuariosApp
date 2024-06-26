﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsuariosApp.Application.Models.AtualizarDados
{
    public class AtualizarDadosRequestModel
    {        
        public string? Nome { get; set; }

        public string? Sobrenome { get; set; }        

        public DateTime? DataNascimento { get; set; }

        public string? Sexo { get; set; }       

        public string? Endereco { get; set; }

        public string? Telefone { get; set; }

        public byte[]? FotoPerfil { get; set; }
    }
}
