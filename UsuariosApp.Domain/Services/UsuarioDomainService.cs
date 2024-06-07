using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsuariosApp.Domain.Entities;
using UsuariosApp.Domain.Enums;
using UsuariosApp.Domain.Helpers;
using UsuariosApp.Domain.Interfaces.Messages;
using UsuariosApp.Domain.Interfaces.Repositories;
using UsuariosApp.Domain.Interfaces.Security;
using UsuariosApp.Domain.Interfaces.Services;

namespace UsuariosApp.Domain.Services
{
    public class UsuarioDomainService : IUsuarioDomainService
    {
        private readonly IUsuarioRepository? _usuarioRepository;
        private readonly IHistoricoUsuarioRepository? _historicoUsuarioRepository;
        private readonly ITokenSecurity? _tokenSecurity;
        private readonly IUsuarioMessage? _usuarioMessage;

        public UsuarioDomainService(IUsuarioRepository? usuarioRepository, IHistoricoUsuarioRepository? historicoUsuarioRepository, ITokenSecurity? tokenSecurity, IUsuarioMessage? usuarioMessage)
        {
            _usuarioRepository = usuarioRepository;
            _historicoUsuarioRepository = historicoUsuarioRepository;
            _tokenSecurity = tokenSecurity;
            _usuarioMessage = usuarioMessage;
        }

        public Usuario AtualizarDados(string? email, string nome, string sobrenome, string sexo, string endereco, string telefone, byte[] fotoPerfil)
        {
            var usuario = _usuarioRepository?.Get(email);

            if (usuario == null)
            {
                throw new ApplicationException("Usuário não encontrado.");
            }

            var dadosAtualizados = false;

            if (!string.IsNullOrWhiteSpace(nome))
            {
                usuario.Nome = nome;
                dadosAtualizados = true;
            }

            if (!string.IsNullOrWhiteSpace(sobrenome))
            {
                usuario.Sobrenome = sobrenome;
                dadosAtualizados = true;
            }                               

            if (!string.IsNullOrWhiteSpace(sexo))
            {
                usuario.Sexo = sexo;
                dadosAtualizados = true;
            }

            if (!string.IsNullOrWhiteSpace(endereco))
            {
                usuario.Endereco = endereco;
                dadosAtualizados = true;
            }

            if (!string.IsNullOrWhiteSpace(telefone))
            {
                usuario.Telefone = telefone;
                dadosAtualizados = true;
            }

            if (fotoPerfil != null && fotoPerfil.Length > 0)
            {
                usuario.FotoPerfil = fotoPerfil;
                dadosAtualizados = true;
            }

            if (dadosAtualizados)
            {
                _usuarioRepository?.Update(usuario);
            }
            else
            {
                throw new ApplicationException("Não foram feitas alterações");
            }

            var to = usuario.Email;
            var subject = "Alteração de dados cadastrais";
            var body = @$"
                <div style='padding: 40px; margin: 40px; border: 1px solid #ccc; text-align: center;'>                                        
                    <h5>Olá {usuario.Nome}{usuario.Sobrenome}</h5>
                    <p>Seus dados foram alterados com sucesso!</p>                    
                    <br/>                    
                </div>
            ";

            _usuarioMessage?.SendMessage(to, subject, body);

            return usuario;

        }

        public Usuario Autenticar(string email, string senha)
        {
            var usuario = _usuarioRepository?.Get(email, MD5Helper.Encrypt(senha));

            if(usuario == null)
            {
                throw new ApplicationException("Acesso negado.");
            }

            var historicoAtividadeUsuario = new HistoricoAtividadeUsuario
            {
                Id = Guid.NewGuid(),
                Tipo = TipoAtividade.AUTENTICAÇÃO,
                DataHora = DateTime.Now,
                Descricao = $"Autenticação do {usuario.Nome} realizada com sucesso.",
                UsuarioId = usuario.Id
            };

            _historicoUsuarioRepository?.Create(historicoAtividadeUsuario);

            usuario.AccessToken = _tokenSecurity?.GenerateToken(usuario);

            return usuario;
        }

        public void CriarConta(Usuario usuario)
        {
            if (_usuarioRepository?.Get(usuario.Email) != null)
            {
                throw new ApplicationException("O email informado já está cadastrado.");
            }

            usuario.Senha = MD5Helper.Encrypt(usuario.Senha);

            _usuarioRepository?.Create(usuario);

            var to = usuario.Email;
            var subject = "Conta Cadastrada com sucesso!";
            var body = @$"
                <div style='padding: 40px; margin: 40px; border: 1px solid #ccc; text-align: center;'>                                        
                    <h5>Olá {usuario.Nome}{usuario.Sobrenome}</h5>
                    <p>Parabens!</p>
                    <p>Sua conta foi cadastrada com Sucesso.</p>                    
                    <br/>                    
                </div>
            ";

            _usuarioMessage?.SendMessage(to, subject, body);

            var historicoAtividadeUsuario = new HistoricoAtividadeUsuario
            {
                Id = Guid.NewGuid(),
                Tipo = TipoAtividade.CRIAÇÃO_DE_USUÁRIO,
                DataHora = DateTime.Now,
                Descricao = $"Cadastro do usuário {usuario.Nome} realizado com sucesso.",
                UsuarioId = usuario.Id
            };

            _historicoUsuarioRepository?.Create(historicoAtividadeUsuario);
        }

        Usuario IUsuarioDomainService.AtualizarEmail(string? email, string novoEmail)
        {
            var usuario = _usuarioRepository?.Get(email);

            if(usuario == null)
            {
                throw new ApplicationException("Usuário não encontrado.");
            }

            var EmailAtualizado = false;

            if (!string.IsNullOrWhiteSpace(novoEmail))
            {
                usuario.Email = novoEmail;
                EmailAtualizado = true;
            }

            if (EmailAtualizado)
            {
                _usuarioRepository?.Update(usuario);
            }
            else
            {
                throw new ApplicationException("Não foi feito alterações.");
            }

            var to = usuario.Email;
            var subject = "Alteração de email";
            var body = @$"
                <div style='padding: 40px; margin: 40px; border: 1px solid #ccc; text-align: center;'>                                        
                    <h5>Olá {usuario.Nome}{usuario.Sobrenome}</h5>
                    <p>Seu email foi alterado com sucesso!</p>                    
                    <br/>                    
                </div>
            ";

            _usuarioMessage?.SendMessage(to, subject, body);

            return usuario;
        }

        Usuario IUsuarioDomainService.AtualizarSenha(string? email, string senha )
        {
            var usuario = _usuarioRepository?.Get(email);

            if (usuario == null)
            {
                throw new ApplicationException("Usuário não encontrado.");
            }

            var SenhaAtualizada = false;

            if (!string.IsNullOrWhiteSpace(senha))
            {
                usuario.Senha = MD5Helper.Encrypt(senha);
                SenhaAtualizada = true;
            }

            if (SenhaAtualizada)
            {
                _usuarioRepository?.Update(usuario);
            }
            else
            {
                throw new ApplicationException("Não foram feitas alterações");
            }

            var to = usuario.Email;
            var subject = "Alteração de senha";
            var body = @$"
                <div style='padding: 40px; margin: 40px; border: 1px solid #ccc; text-align: center;'>                                        
                    <h5>Olá {usuario.Nome}{usuario.Sobrenome}</h5>
                    <p>Sua senha foi alterada com sucesso!</p>                    
                    <br/>                    
                </div>
            ";

            _usuarioMessage?.SendMessage(to, subject, body);

            return usuario;
        }
    }
}
