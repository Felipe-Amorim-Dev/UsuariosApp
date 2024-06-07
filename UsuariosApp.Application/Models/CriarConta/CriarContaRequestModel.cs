﻿using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsuariosApp.Domain.Enums;

namespace UsuariosApp.Application.Models.CriarConta
{
    public class CriarContaRequestModel
    {
        [Required(ErrorMessage ="Informe o nome de usuário.")]
        public string? Nome { get; set; }

        [Required(ErrorMessage = "Informe o sobrenome de usuário.")]
        public string? Sobrenome { get; set; }

        [EmailAddress(ErrorMessage ="Email inválido.")]
        [Required(ErrorMessage = "Informe o email de usuário.")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "Informe a senha de usuário.")]
        public string? Senha { get; set; }

        [Required(ErrorMessage = "Informe a data de nascimento do usuário.")]
        public DateTime? DataNascimento { get; set; }

        [Required(ErrorMessage = "Informe o Gênero do usuário.")]
        public string? Sexo { get; set; }

        [Required(ErrorMessage = "Informe o endereço do usuário.")]
        public string? Endereco { get; set; }

        [Required(ErrorMessage = "Informe o telefone do usuário.")]
        public string? Telefone { get; set; }
        
        public byte[]? FotoPerfil { get; set; }

        [Compare("Senha", ErrorMessage = "Confirme a senha de usuário.")]
        [Required(ErrorMessage = "Confirme a senha de usuário.")]
        public string? SenhaConfirmacao { get; set; }
    }
}
