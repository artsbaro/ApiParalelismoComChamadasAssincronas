using BffApiParalelismoComChamadasAssincronas.Services;
using BffApiParalelismoComChamadasAssincronas.Services.DataService;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IPessoaDataService, PessoaDataService>();
builder.Services.AddScoped<IEnderecoDataService, EnderecoDataService>();

builder.Services.AddScoped<IPessoaService, PessoaService>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
