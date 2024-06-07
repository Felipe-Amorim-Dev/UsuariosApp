using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsuariosApp.Domain.Entities;
using UsuariosApp.Domain.Enums;
using UsuariosApp.Domain.Interfaces.Repositories;

namespace UsuariosApp.Domain.Interfaces.Services
{
    public interface IUsuarioDomainService
    {
        void CriarConta(Usuario usuario);

        Usuario Autenticar(string email, string senha);        

        Usuario AtualizarDados(
            string? email, 
            string nome, 
            string sobrenome,                        
            string sexo,
            string endereco,
            string telefone,
            byte[]? fotoPerfil
            );

        Usuario AtualizarSenha(string? email, string senha);

        Usuario AtualizarEmail(string? email, string novoEmail);
    }
}
