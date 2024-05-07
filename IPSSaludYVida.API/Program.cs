using IPSSaludYVida.API;
using IPSSaludYVida.API.Db;
using IPSSaludYVida.API.Interfaces;
using IPSSaludYVida.API.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;


var builder = WebApplication.CreateBuilder(args);



// Add services to the container.


//Inyección de dependencias. 
var configuration = builder.Services.BuildServiceProvider().GetService<IConfiguration>();

builder.Services.AddDbContext<dbIPSSaludYVidaContext>(options =>
{
    options.UseSqlServer(configuration.GetConnectionString("dbConnection"));
},ServiceLifetime.Transient);

builder.Services.AddScoped<IMasterRepository, MasterRepository>();
builder.Services.AddScoped<IOposicionDonacionRepository, OposicionDonacionRepository>();
builder.Services.AddScoped<IVoluntadAnticipadaRepository, VoluntadAnticipadaRepository>();
builder.Services.AddScoped<IUsuarioPaisesRepository, UsuarioPaisesRepository>();
builder.Services.AddScoped<IUsuarioDiscapacidadRepository, UsuarioDiscapacidadRepository>();
builder.Services.AddScoped<IUsuariosRepository, UsuariosRepository>();
builder.Services.AddScoped<IServicioSaludRepository, ServicioSaludRepository>();
builder.Services.AddScoped<ITriageRepository, TriageRepository>();

////////////////////////////////////////////////////////////////////////////////////

builder.Services.AddControllersWithViews().AddJsonOptions(options =>
        options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(o => o.AddPolicy("CustomPolicyCors", builder =>
{
    builder.AllowAnyMethod()
    .AllowAnyHeader()
    .SetIsOriginAllowed((host) => true)
    .AllowCredentials();
}));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseCors("CustomPolicyCors");

app.MapControllers();

app.Run();
