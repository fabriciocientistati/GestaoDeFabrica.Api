using System.Text;
using System.Text.Json.Serialization;
using FabricaGestao.Api.Dados.Contexto;
using FabricaGestao.Api.Servicos;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace FabricaGestao.Api.Extencoes;

public static class AppExtensao
{
    public static void CarregaConfiguracaoDoAppSettings(this WebApplicationBuilder builder)
    {
        Configuracao.JwtChave = builder.Configuration.GetValue<string>("JwtChave");
        Configuracao.ChaveApiNome = builder.Configuration.GetValue<string>("ChaveApiNome");
        Configuracao.ChaveApi = builder.Configuration.GetValue<string>("ChaveApi");
    }
    public static void ConfiguracacaoDeAutenticacao(this WebApplicationBuilder builder)
    {
        var token = Encoding.ASCII.GetBytes(Configuracao.JwtChave);
        builder.Services.AddAuthentication(x =>
        {
            x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        }).AddJwtBearer(x =>
        {
            x.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(token),
                ValidateIssuer = false,
                ValidateAudience = false
            };
        });
    }
    public static void ConfiguracaoMVC(this WebApplicationBuilder builder)
    {
        builder.Services.AddMemoryCache();
        
        builder.Services.AddControllers()
            .ConfigureApiBehaviorOptions(options =>
            {
                options.SuppressModelStateInvalidFilter = true;
            })
            .AddJsonOptions(x =>
            {
                x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
                x.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingDefault;
            });
    
    }
    public static void ConfiguracaoServicos(this WebApplicationBuilder builder)
    {
        var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
        builder.Services.AddDbContext<ContextoDados>(options => options.UseSqlServer(connectionString));
        builder.Services.AddTransient<TokenServicos>();
    }
}