using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsuariosApp.Application.Models.AtualizarDados;
using UsuariosApp.Application.Models.AtualizarEmail;
using UsuariosApp.Application.Models.AtualizarSenha;
using UsuariosApp.Application.Models.Autenticar;
using UsuariosApp.Application.Models.CriarConta;

namespace UsuariosApp.Application.Interfaces
{
    public interface IUsuarioAppService
    {
        CriarContaResponseModel CriarConta(CriarContaRequestModel model);

        AutenticarResponseModel Autenticar(AutenticarRequestModel model);

        AtualizarDadosResponseModel AtualizarDados(AtualizarDadosRequestModel model, string email);

        AtualizarSenhaResponseModel AtualizarSenha(AtualizarSenhaRequestModel model, string email);

        AtualizarEmailResponseModel AtualizarEmail(AtualizarEmailRequestModel model, string email);
        
    }
}
