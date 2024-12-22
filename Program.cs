
using FabricaGestao.Api.Extencoes;

var builder = WebApplication.CreateBuilder(args);

builder.CarregaConfiguracaoDoAppSettings();
builder.ConfiguracacaoDeAutenticacao();
builder.ConfiguracaoMVC();
builder.ConfiguracaoServicos();

builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

if (app.Environment.IsDevelopment())
{
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    } 
}

app.Run();

