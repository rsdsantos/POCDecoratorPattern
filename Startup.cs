using Communication.API.Application.Commands;
using Communication.API.Application.Decorators;
using Communication.API.Domain.Interfaces;
using Communication.API.Infrastructure;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;

namespace Communication.API
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);            

            // Injeção simples de Command e Handler:
            //services.AddTransient<ICommandHandler<SendEmailCommand>, SendEmailCommandHandler>();

            // Injeção com Decorator:
            services.AddTransient<ICommandHandler<SendEmailCommand>>(provider =>
                new AuditLogDecorator<SendEmailCommand>(
                    new SendEmailCommandHandler(),
                    provider.GetService<ILogger<string>>()));

            services.AddSingleton<Messages>();

            services.AddSwaggerGen(c => c.SwaggerDoc("v1", new OpenApiInfo { Title = "POC Decorator Pattern", Version = "v1" }));
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "POC Decorator Pattern V1");
            });

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
