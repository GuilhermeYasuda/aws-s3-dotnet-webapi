using Amazon.S3;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

// carrega a configuração da AWS do arquivo appsettings.json para o ambiente de execução da aplicação
builder.Services.AddDefaultAWSOptions(builder.Configuration.GetAWSOptions());
// registra o serviço do Amazon S3 para ser injetado em outros componentes da aplicação para trabalhar com buckets e objetos
builder.Services.AddAWSService<IAmazonS3>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
