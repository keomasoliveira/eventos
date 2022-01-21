using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

using API.Persistence;
using API.Application;
using API.Application.Contract;

namespace API
{
  public class Startup
  {
    public Startup(IConfiguration configuration)
    {
      Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    // This method gets called by the runtime. Use this method to add services to the container.
    public void ConfigureServices(IServiceCollection services)
    {
      services.AddDbContext<EventosContext>(
        context => context.UseSqlServer(Configuration.GetConnectionString("db")));
      services.AddControllers()
      .AddNewtonsoftJson(x => x.SerializerSettings.ReferenceLoopHandling =
      Newtonsoft.Json.ReferenceLoopHandling.Ignore);
      services.AddScoped<IEventosService, EventoService>();
      services.AddScoped<GeralPersist, GeralInterfacePersistence>();
      services.AddScoped<EventoPersist, EventoInterfacePersistence>();
      services.AddCors();
      services.AddSwaggerGen(c =>
      {
        c.SwaggerDoc("v1", new OpenApiInfo { Title = "EVENTOS API", Version = "v1" });
      });
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {

      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
        app.UseSwagger();
        app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "EVENTOS.API v1"));


      }
      else
      {
        app.UseHttpsRedirection();
      }



      app.UseRouting();

      app.UseAuthorization();

      app.UseCors(x => x
      .AllowAnyHeader()
      .AllowAnyMethod()
      .AllowAnyOrigin());


      app.UseEndpoints(endpoints =>
                {
                  endpoints.MapControllers();
                });
    }
  }
}
