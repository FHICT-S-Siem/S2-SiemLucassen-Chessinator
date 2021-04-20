using Blazored.SessionStorage;
using Chessinator.Application.Cryptography;
using Chessinator.Application.Interfaces;
using Chessinator.Application.Services;
using Chessinator.Persistence.Contexts;
using Chessinator.Persistence.Repositories;
using Chessinator.Presentation.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Chessinator.Presentation
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAutoMapper(typeof(Startup));
            services.AddRazorPages();
            services.AddServerSideBlazor();
            services.AddOptions();

            //Adds Session storage
            services.AddBlazoredSessionStorage();

            // Adds the database connection to the service collection for dependency injection.
            services.AddDbContext<ChessinatorDbContext>(options =>
                          options.UseSqlServer(
                              Configuration.GetConnectionString("DefaultConnection")));

            services.AddScoped<IPasswordHasher, PasswordHasher>();
            services.AddScoped<ISaltGenerator, RandomSaltGenerator>();

            // Adds the repositories with their interfaces.
            services.AddScoped<ITournamentRepository, TournamentRepository>();
            services.AddScoped<IUserRepository, UserRepository>();

            // Adds the services with their interfaces.
            services.AddScoped<ITournamentService, TournamentService>();
            services.AddScoped<IUserService, UserService>();

            // Adds AuthenticationStateProvider with the CustomAuthenticationStateProvider
            services.AddScoped<AuthenticationStateProvider, CustomAuthenticationStateProvider>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            // Authentication
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapBlazorHub();
                endpoints.MapFallbackToPage("/_Host");
            });
        }
    }
}
