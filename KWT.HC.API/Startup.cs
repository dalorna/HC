using System;
using System.Collections.Generic;
using AutoMapper;
using EDT_ActiveDirectory;
using EDT_ActiveDirectory.Contracts;
using EDT_ActiveDirectory.Models;
using KWT.HC.API.ComponentRegistration;
using KWT.HC.API.Entity;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.AzureAD.UI;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Graph;
using Microsoft.OpenApi.Models;

namespace EWT.HC.API
{
    public class Startup
    {
        private readonly AzureADConfig _azureADConfig;
        readonly string AllowedOrigins = "_allowedOrigins";
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;

            //TODO add any appsetting configurations
            _azureADConfig = new AzureADConfig();
            Configuration.GetSection("AzureAd").Bind(_azureADConfig);
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAuthentication(AzureADDefaults.JwtBearerAuthenticationScheme)
                .AddAzureADBearer(options => Configuration.Bind("AzureAd", options));

            //// inject the graph we want
            //services.AddScoped<IAuthenticationProvider, GraphAppAuthProvider>();
            //// inject the active directory manager
            //services.AddScoped<IActiveDirectoryManager, ActiveDirectoryManager>();

            services.AddCors(options =>
            {
                options.AddPolicy(AllowedOrigins,
                builder =>
                {
                    // builder.WithOrigins("http://localhost:4200");
                    // builder.WithOrigins("https://wa-ps-scus-wpl-dev.azurewebsites.net");
                    builder.AllowAnyOrigin();
                    builder.AllowAnyMethod();
                    builder.AllowAnyHeader();
                });
            });

            //auth to all controllers
            // services.AddControllers(); //TODO: Add authentication Filter

            services.AddControllers(options =>
            {
                var policy = new AuthorizationPolicyBuilder()
                    .RequireAuthenticatedUser()
                    .Build();
                options.Filters.Add(new AuthorizeFilter(policy));
            });

            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo { Title = "HOT Commission", Version = "v1" });
                options.CustomOperationIds(apiDesc => null);
                options.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
                {
                    Type = SecuritySchemeType.OAuth2,
                    Flows = new OpenApiOAuthFlows
                    {
                        Implicit = new OpenApiOAuthFlow
                        {
                            Scopes = new Dictionary<string, string>
                            {
                                ["User.Read"] = "Read user Profile"
                            },
                            AuthorizationUrl = new Uri($"https://login.microsoftonline.com/{Configuration["AzureAD:TenantId"]}/oauth2/authorize")
                        }
                    }
                });
                options.AddSecurityRequirement(new OpenApiSecurityRequirement {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "oauth2"
                            }
                        }, new List<string>()
                    }
                });
            });

            //Add any component registrations (dependency injection)
            // services.Add(new ServiceDescriptor(typeof(AzureADConfig), _azureADConfig));
            services.AddAutoMapper(typeof(Startup));

            services.AddTransient<DbContext>(s => new HotContext(Configuration.GetConnectionString("hotdatabase")));
            ComponentRegistration.RegisterComponents(services);
            services.AddApplicationInsightsTelemetry(Configuration);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.OAuthClientId(Configuration["Swagger:ClientId"]);
                c.OAuthClientSecret(Configuration["Swagger:ClientSecret"]);
                c.OAuthRealm(Configuration["AzureAD:ClientId"]);
                c.OAuthAppName("Hot Commission API V1");
                c.OAuthScopeSeparator(" ");
                c.OAuthAdditionalQueryStringParams(new Dictionary<string, string> { { "resource", Configuration["AzureAD:ClientId"] } });
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Hot Commission V1");
            });
            app.UseHttpsRedirection();

            app.UseRouting();
            app.UseCors(AllowedOrigins);

            app.UseAuthentication();
            // checks for authentication
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
