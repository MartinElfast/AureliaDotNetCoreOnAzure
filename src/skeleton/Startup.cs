﻿using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Logging;
using skeleton.Data;
using skeleton.Repository;
using System.IO;

namespace skeleton {
    public class Startup {
        public static void Main( string[] args ) {
            var host = new WebHostBuilder()
                .UseKestrel()
                .UseContentRoot(Directory.GetCurrentDirectory())
                .UseIISIntegration()
                .UseStartup<Startup>()
                .Build();

            host.Run();
        }

        public Startup( IHostingEnvironment env ) {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true);

            if ( env.IsDevelopment() ) {
                // For more details on using the user secret store see http://go.microsoft.com/fwlink/?LinkID=532709
                builder.AddUserSecrets();

                // This will push telemetry data through Application Insights pipeline faster, allowing you to view results immediately.
                builder.AddApplicationInsightsSettings( developerMode: true );
            }

            builder.AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices( IServiceCollection services ) {
            services.AddApplicationInsightsTelemetry( Configuration );

            services.AddMvc();

            services.AddScoped<IArtistRepo, ArtistRepo>();

            services.AddScoped<AssetMapper>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure( IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory ) {
            loggerFactory.AddConsole( Configuration.GetSection( "Logging" ) );
            loggerFactory.AddDebug();

            app.UseDefaultFiles();
            app.UseDeveloperExceptionPage();
            app.UseStatusCodePages();
            app.UseCors( o =>
                o.WithOrigins( "http://localhost:5000", "http://bohuskonst.azurewebsites.net/" )
                .AllowAnyHeader()
                .AllowAnyMethod()
                .AllowCredentials() );

            if ( env.IsDevelopment() ) {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();

                //This allows you to debug your ts files in browser using the mappings provided by gulp-typescript
                app.UseStaticFiles( new StaticFileOptions() {
                    FileProvider = new PhysicalFileProvider( Path.Combine( Directory.GetCurrentDirectory(), @"src" ) ),
                    RequestPath = new PathString( "/src" )
                } );

            } else {
                app.UseExceptionHandler( "/Home/Error" );
            }

            app.UseStaticFiles();

            // Add external authentication middleware below. To configure them please see http://go.microsoft.com/fwlink/?LinkID=532715

            app.UseMvc( routes => {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}" );
            } );
        }
    }
}
