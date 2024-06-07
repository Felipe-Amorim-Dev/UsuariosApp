using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UsuariosApp.Application.Interfaces;
using UsuariosApp.Application.Models.AtualizarDados;
using UsuariosApp.Application.Models.AtualizarEmail;
using UsuariosApp.Application.Models.AtualizarSenha;
using UsuariosApp.Application.Models.Autenticar;
using UsuariosApp.Application.Models.CriarConta;

namespace UsuarioApp.Services.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly IUsuarioAppService _usuarioAppService;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public UsuariosController(IUsuarioAppService usuarioAppService, IWebHostEnvironment webHostEnvironment)
        {
            _usuarioAppService = usuarioAppService;
            _webHostEnvironment = webHostEnvironment;
        }

        [Route("criar-conta")]
        [HttpPost]
        [ProducesResponseType(typeof(CriarContaResponseModel), 200)]
        public IActionResult CriarConta([FromForm] CriarContaRequestModel model, IFormFile fotoPerfil)
        {
            try
            {
                using (var memoryStream = new MemoryStream())
                {
                    fotoPerfil.CopyTo(memoryStream);
                    model.FotoPerfil = memoryStream.ToArray();
                }

                var response = _usuarioAppService?.CriarConta(model);
                return StatusCode(200, response);
            }
            catch (ApplicationException e) 
            {
                return StatusCode(400, new { e.Message });
            }
            catch(Exception e)
            {
                return StatusCode(500, new { e.Message });
            }
        }

        [Route("autenticar")]
        [HttpPost]
        [ProducesResponseType(typeof(AutenticarResponseModel), 200)]
        public IActionResult Autenticar([FromBody] AutenticarRequestModel model)
        {
            try
            {
                var response = _usuarioAppService?.Autenticar(model);
                return StatusCode(200, response);
            }
            catch (ApplicationException e) 
            {
                return StatusCode(400, new { e.Message });
            }
            catch (Exception e)
            {
                return StatusCode(500, new { e.Message });
            }
        }

        [Authorize]
        [Route("atualizar-dados")]
        [HttpPut]
        [ProducesResponseType(typeof(AtualizarDadosResponseModel), 200)]
        public IActionResult AtualizarDados([FromForm] AtualizarDadosRequestModel model, IFormFile? fotoPerfil)
        {
            try
            {          
                var email = User.Identity.Name;

                if(fotoPerfil != null) { 
                    using (var memoryStream = new MemoryStream())
                    {
                        fotoPerfil.CopyTo(memoryStream);
                        model.FotoPerfil = memoryStream.ToArray();
                    }
                }
                var response = _usuarioAppService.AtualizarDados(model, email);
                return StatusCode(200, response);
            }
            catch(ApplicationException e)
            {
                return StatusCode(400, new { e.Message });
            }
            catch (Exception e)
            {
                return StatusCode(500, new { e.Message });
            }
        }

        [Authorize]
        [Route("atualizar-senha")]
        [HttpPut]
        [ProducesResponseType(typeof(AtualizarSenhaResponseModel), 200)]
        public IActionResult AtualizarSenha([FromBody] AtualizarSenhaRequestModel model)
        {
            try
            {
                var email = User.Identity.Name;
                
                var response = _usuarioAppService.AtualizarSenha(model, email);
                return StatusCode(200, response);
            }
            catch (ApplicationException e)
            {
                return StatusCode(400, new { e.Message });
            }
            catch (Exception e)
            {
                return StatusCode(500, new { e.Message });
            }
        }

        [Authorize]
        [Route("atualizar-email")]
        [HttpPut]
        [ProducesResponseType(typeof(AtualizarEmailResponseModel), 200)]
        public IActionResult AtualizarEmail([FromBody] AtualizarEmailRequestModel model)
        {
            try
            {
                var email = User.Identity.Name;

                var response = _usuarioAppService.AtualizarEmail(model, email);
                return StatusCode(200, response);
            }
            catch (ApplicationException e)
            {
                return StatusCode(400, new { e.Message });
            }
            catch (Exception e)
            {
                return StatusCode(500, new { e.Message });
            }
        }
    }
}
