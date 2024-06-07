using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using UsuariosApp.Application.Interfaces;
using UsuariosApp.Application.Services;
using UsuariosApp.Domain.Interfaces.Messages;
using UsuariosApp.Domain.Interfaces.Repositories;
using UsuariosApp.Domain.Interfaces.Security;
using UsuariosApp.Domain.Interfaces.Services;
using UsuariosApp.Domain.Services;
using UsuariosApp.Infra.Data.Repositories;
using UsuariosApp.Messages.Services;
using UsuariosApp.Security.Services;
using UsuariosApp.Security.Settings;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddRouting(config => config.LowercaseUrls = true);
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddTransient<IUsuarioAppService, UsuarioAppService>();
builder.Services.AddTransient<IUsuarioDomainService, UsuarioDomainService>();
builder.Services.AddTransient<IUsuarioRepository, UsuarioRepository>();
builder.Services.AddTransient<IUsuarioMessage, UsuarioMessageProducer>();
builder.Services.AddTransient<IHistoricoUsuarioRepository, HistoricoAtividadeUsuarioRepository>();
builder.Services.AddTransient<ITokenSecurity, TokenSecurity>();
builder.Services.AddHostedService<UsuarioMessageConsumer>();

builder.Services.AddCors(
          config => config.AddPolicy("DefaultPolicy", builder =>
          {
              builder.AllowAnyOrigin() //qualquer dominio poderá acessar a API
                     .AllowAnyMethod() //permitir POST, PUT, DELETE, GET
                     .AllowAnyHeader(); //aceitar parametros de cabeçalho de requisição
          })
          );

builder.Services.AddAuthentication(
    auth =>
    {
        auth.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        auth.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    }).AddJwtBearer(
        bearer =>
        {
            bearer.RequireHttpsMetadata = false;
            bearer.SaveToken = true;
            bearer.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey
                    (Encoding.ASCII.GetBytes(TokenSettings.SecretKey)),
                ValidateIssuer = false,
                ValidateAudience = false
            };
        }
);

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseAuthentication();
app.UseAuthorization();

app.UseCors("DefaultPolicy");

app.MapControllers();

app.Run();

public partial class program { }
