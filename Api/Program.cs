using Microsoft.EntityFrameworkCore;
using SicoApi.Data.BD_Context;
using SicoApi.Data.Repositories;
using SicoApi.Services.Interface;
using SicoApi.Services.Service;
using System.Text.Json.Serialization;

namespace SicoApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();



            #region Conexion de sql
            builder.Services.AddDbContext<SicoTestContext>(opciones =>
            {
                opciones.UseSqlServer(builder.Configuration.GetConnectionString("cadenaConexion"));
            });
            #endregion

            #region Inyeccion de dependencias 
            builder.Services.AddScoped<IGenericRepository<Estudiante>, EstudianteRepository>();

            builder.Services.AddScoped<IGenericRepository<Curso>, CursoRepository>();
            builder.Services.AddScoped<IGenericRepository<EstudianteXCurso>, EstudianteXCursoRepository>();



            builder.Services.AddScoped<IEstudiante, EstudianteService>();

            builder.Services.AddScoped<ICurso, CursoService>();

            builder.Services.AddScoped<IEstudianteXCurso, EstudianteXCursoService>();

            #endregion

            #region  configuracion para quitar la serializacion de json de referencias ciclicas
            builder.Services.AddControllers().AddJsonOptions(opt => opt.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
            #endregion

            #region configuracion para activacion de CORS
            var MyRulesCors = "SicoApiRules";

            builder.Services.AddCors(opt => opt.AddPolicy(name: MyRulesCors, builder =>
            {
                builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();

            }));

            #endregion

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment() || app.Environment.IsProduction())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            #region ejecucion del cors
            app.UseCors(MyRulesCors);
            #endregion

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
