using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsuariosApp.Application.Interfaces;
using UsuariosApp.Application.Models.AtualizarDados;
using UsuariosApp.Application.Models.AtualizarEmail;
using UsuariosApp.Application.Models.AtualizarSenha;
using UsuariosApp.Application.Models.Autenticar;
using UsuariosApp.Application.Models.CriarConta;
using UsuariosApp.Domain.Entities;
using UsuariosApp.Domain.Interfaces.Services;

namespace UsuariosApp.Application.Services
{
    public class UsuarioAppService : IUsuarioAppService
    {
        private readonly IUsuarioDomainService? _usuarioDomainService;

        public UsuarioAppService(IUsuarioDomainService? usuarioDomainService)
        {
            _usuarioDomainService = usuarioDomainService;
        }

        public AtualizarDadosResponseModel AtualizarDados(AtualizarDadosRequestModel model, string email)
        {
            var usuario = _usuarioDomainService?.AtualizarDados(email, model.Nome, model.Sobrenome, model.Sexo, model.Endereco, model.Telefone, model?.FotoPerfil);

            var response = new AtualizarDadosResponseModel
            {
                Id = usuario.Id,
                Nome = usuario.Nome,
                Email = usuario.Email,
                DataHoraAlteracao = DateTime.Now
            };

            return response;
        }

        public AutenticarResponseModel Autenticar(AutenticarRequestModel model)
        {
            var usuario = _usuarioDomainService?.Autenticar(model.Email, model.Senha);

            var response = new AutenticarResponseModel
            {
                Id = usuario.Id,
                Nome = usuario.Nome,
                Sobrenome = usuario.Sobrenome,
                Email = usuario.Email,
                DataNascimento = usuario.DataNascimento,
                Sexo = usuario.Sexo,
                Endereco = usuario.Endereco,
                Telefone = usuario.Telefone,
                FotoPerfil = usuario.FotoPerfil,
                AccessToken = usuario.AccessToken,
                DataHoraAcesso = DateTime.Now,
                DataHoraExpiracao = DateTime.UtcNow.AddHours(2)
            };

            return response;
        }

        public CriarContaResponseModel CriarConta(CriarContaRequestModel model)
        {
            var usuario = new Usuario
            {
                Id = Guid.NewGuid(),
                Nome = model.Nome,
                Sobrenome = model.Sobrenome,
                Email = model.Email,
                Senha = model.Senha,
                DataNascimento = model.DataNascimento,
                Sexo = model.Sexo,
                Endereco = model.Endereco,
                Telefone = model.Telefone,
                FotoPerfil = model.FotoPerfil,
                DataHoraCriacao = DateTime.Now,
                DataHoraAlteracao = DateTime.Now
            };

            _usuarioDomainService?.CriarConta(usuario);

            var response = new CriarContaResponseModel
            {
                Id = usuario.Id,
                Nome = usuario.Nome,
                Email = usuario.Email,
                DataHoraCriacao = usuario.DataHoraCriacao
            };

            return response;
        }   
        
        public AtualizarSenhaResponseModel AtualizarSenha(AtualizarSenhaRequestModel model, string email)
        {
            var usuario = _usuarioDomainService?.AtualizarSenha(email, model.Senha);

            var response = new AtualizarSenhaResponseModel
            {
                Id = usuario.Id,
                Nome = usuario.Nome,
                Email = usuario.Email,
                DataHoraAlteracao = DateTime.Now
            };

            return response;
        }

        AtualizarEmailResponseModel IUsuarioAppService.AtualizarEmail(AtualizarEmailRequestModel model, string email)
        {
            var usuario = _usuarioDomainService?.AtualizarEmail(email, model.NovoEmail);

            var response = new AtualizarEmailResponseModel
            {
                Id = usuario.Id,
                Email = usuario.Email,
                DataHoraAlteracao = DateTime.Now
            };

            return response;
        }
    }
}
