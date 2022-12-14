using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using ProBarbearia.Application.Contratos;
using ProBarbearia.Application.Services;
using ProBarbearia.Domain.Identity;
using ProBarbearia.Persistence;
using ProBarbearia.Persistence.Contextos;
using ProBarbearia.Persistence.Contratos;

namespace probarbearia.API
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

            services.AddDbContext<ProBarbeariaContext>(
                context => context.UseSqlServer(Configuration.GetConnectionString("Default"))
            );

            services.AddIdentityCore<User>(options =>
            {
                options.Password.RequireDigit = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;
                options.Password.RequiredLength = 6;
                
            })
            .AddRoles<Role>()
            .AddRoleManager<RoleManager<Role>>()
            .AddSignInManager<SignInManager<User>>()
            .AddRoleValidator<RoleValidator<Role>>()
            .AddEntityFrameworkStores<ProBarbeariaContext>()
            .AddDefaultTokenProviders();

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                   .AddJwtBearer(options =>
                   {
                       options.TokenValidationParameters = new TokenValidationParameters
                       {
                           ValidateIssuerSigningKey = true,
                           IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["TokenKey"])),
                           ValidateIssuer = false,
                           ValidateAudience = false
                       };
                   });

            services.AddControllers()
                    .AddJsonOptions(options =>
                        options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter())
                    )
                    .AddNewtonsoftJson(options => options.SerializerSettings.ReferenceLoopHandling =
                        Newtonsoft.Json.ReferenceLoopHandling.Ignore
                    );

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            services.AddScoped<ITokenServico, TokenServico>();
            services.AddScoped<IUsuarioServico, UsuarioServico>();
            services.AddScoped<IEstabelecimentoServico, EstabelecimentoServico>();
            services.AddScoped<IEstabelecimentoUsuarioServico, EstabelecimentoUsuarioServico>();
            services.AddScoped<ICidadeServico, CidadeServico>();
            services.AddScoped<IEstadoServico, EstadoServico>();
            services.AddScoped<IServicoServico, ServicoServico>();
            services.AddScoped<IProfissionalServico, ProfissionalServico>();
            services.AddScoped<IServicoProfissionalServico, ServicoProfissionalServico>();
            services.AddScoped<IProfissionalHorarioServico, ProfissionalHorarioServico>();
            services.AddScoped<IAgendaServico, AgendaServico>();

            services.AddScoped<IGeralPersistencia, GeralPersistencia>();
            services.AddScoped<IUsuarioPersistencia, UsuarioPersistencia>();
            services.AddScoped<IEstabelecimentoPersistencia, EstabelecimentoPersistencia>();
            services.AddScoped<IEstabelecimentoUsuarioPersistencia, EstabelecimentoUsuarioPersistencia>();
            services.AddScoped<ICidadePersistencia, CidadePersistencia>();
            services.AddScoped<IEstadoPersistencia, EstadoPersistencia>();
            services.AddScoped<IServicoPersistencia, ServicoPersistencia>();
            services.AddScoped<IProfissionalPersistencia, ProfissionalPersistencia>();
            services.AddScoped<IServicoProfissionalPersistencia, ServicoProfissionalPersistencia>();
            services.AddScoped<IProfissionalHorarioPersistencia, ProfissionalHorarioPersistencia>();
            services.AddScoped<IAgendaPersistencia, AgendaPersistencia>();



            services.AddCors();
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo { Title = "ProBarbearia.API", Version = "v1" });
                options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = @"JWT Authorization header usando Bearer.
                                Entre com 'Bearer ' [espa??o] ent??o coloque seu token.
                                Exemplo: 'Bearer 12345abcdef'",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer"
                });

                options.AddSecurityRequirement(new OpenApiSecurityRequirement()
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            },
                            Scheme = "oauth2",
                            Name = "Bearer",
                            In = ParameterLocation.Header
                        },
                        new List<string>()
                    }
                });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "ProBarbearia.API v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseCors(x => x.AllowAnyHeader()
                              .AllowAnyMethod()
                              .AllowAnyOrigin());

            app.UseStaticFiles(new StaticFileOptions()
            {
                FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), "Resources")),
                RequestPath = new PathString("/Resources")
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
