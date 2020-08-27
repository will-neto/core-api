using Loja.Infra.CrossCutting.Identity.Authorization;
using Loja.Infra.CrossCutting.Identity.Data;
using Loja.Infra.CrossCutting.Identity.Models;
using Loja.Infra.CrossCutting.Identity.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loja.Api.Configurations
{
    public static class MvcConfiguration
    {
        public static void AddMvcSecurity(this IServiceCollection services, IConfigurationRoot configuration)
        {
            // IoC
            if (services == null) throw new ArgumentNullException(nameof(services));

            // Obtem as configuracoes no appsetting por secao - JwtTokenOptions
            
            var tokenConfigurations = new TokenDescriptor();

            new ConfigureFromConfigurationOptions<TokenDescriptor>(
                    configuration.GetSection("JwtTokenOptions"))
                .Configure(tokenConfigurations);

            //Deixei estatico pra n ter que fazer instancia
            //services.AddSingleton(tokenConfigurations);

            
            // configuracoes identity

            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();


            // Configuracoes de Autenticacao e Autorizacao do JWT

            var key = Encoding.ASCII.GetBytes(TokenService.Secret);

            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;

                x.TokenValidationParameters = new TokenValidationParameters
                {
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateAudience = false,
                    ValidateIssuer = true,

                    ValidateIssuerSigningKey = false,
                    
                };
            });

            services.AddAuthorization(options =>
            {
                options.AddPolicy("PodeLer", policy => policy.RequireClaim("manager", "read"));
                options.AddPolicy("PodeGravar", policy => policy.RequireClaim("manager", "save"));

                options.AddPolicy("Bearer", new AuthorizationPolicyBuilder()
                    .AddAuthenticationSchemes(JwtBearerDefaults.AuthenticationScheme)
                    .RequireAuthenticatedUser().Build());
            });
        }

    }
}
