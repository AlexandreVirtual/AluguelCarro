using AluguelCarro.AcessoDados.Interfaces;
using AluguelCarro.AcessoDados.Repositorios;
using AluguelCarro.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AluguelCarro
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
            services.AddDbContext<Contexto>(options => options.UseSqlServer(Configuration.GetConnectionString("Conexao")));
            
            services.AddIdentity<Usuario, NiveisAcesso>().AddDefaultUI().AddEntityFrameworkStores<Contexto>();

            services.ConfigureApplicationCookie(opcoes =>
            {
                opcoes.Cookie.HttpOnly = true;
                opcoes.ExpireTimeSpan = TimeSpan.FromMinutes(50);
                opcoes.LoginPath = "/Usuarios/Login";
                opcoes.SlidingExpiration = true;
            });

            services.Configure<IdentityOptions>(opcoes =>
            {
                opcoes.Password.RequireDigit = false;
                opcoes.Password.RequireLowercase = false;
                opcoes.Password.RequireNonAlphanumeric = false;
                opcoes.Password.RequireUppercase = false;
                opcoes.Password.RequiredLength = 6;
                opcoes.Password.RequiredUniqueChars = 1;
            });

            services.AddScoped<INivelAcessoRepositorio, NivelAcessoRepositorio>();
            services.AddScoped<IUsuarioRepositorio, UsuarioRepositorio>();
            services.AddScoped<IEnderecoRepositorio, EnderecoRepositorio>();

            services.AddControllersWithViews();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseMigrationsEndPoint();
            }
           
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });
        }
    }
}
