using AspNet_Api_EfCore.Configurations;
using AspNet_Api_EfCore.Data;
using AspNet_Api_EfCore.Extensions;
using AspNet_Api_EfCore.Services;
using AspNet_Api_EfCore.Services.Interfaces;
using AspNet_Api_EfCore.ValueObjects;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.IO.Compression;
using System.Text;
using System.Text.Json.Serialization;

namespace AspNet_Api_EfCore
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            JWTSettings jwtSettings = AppSettingsConfig.Configuration.GetSection("JWTSettings").Get<JWTSettings>();
            byte[] key = Encoding.ASCII.GetBytes(jwtSettings.JwtKey);

            services.AddAuthentication(opt =>
            {
                opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;

            }).AddJwtBearer(opt =>
            {
                opt.RequireHttpsMetadata = false;
                opt.SaveToken = true;
                opt.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });

            services.AddControllers()
                    .ConfigureApiBehaviorOptions(opt =>
                    {
                        opt.SuppressModelStateInvalidFilter = true;
                    })
                    .AddJsonOptions(opt =>
                    {
                        opt.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
                        opt.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingDefault;
                    });

            services.AddRepositories();
            services.AddHandlers();
            services.AddCustomFormat();
            services.AddServices();

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped<IAuthenticatedUserService, AuthenticatedUserService>();

            services.AddMemoryCache();
            services.AddResponseCompression(opt =>
            {
                opt.Providers.Add<GzipCompressionProvider>();
            });
            services.Configure<GzipCompressionProviderOptions>(opt =>
            {
                opt.Level = CompressionLevel.Optimal;
            });

            string connectionString = AppSettingsConfig.Configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<BlogDataContext>(opt =>
            {
                opt.UseSqlServer(connectionString);
            });

            services.AddAutoMapper(typeof(Startup));
            services.AddMediatR(typeof(Startup));

            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen(opt =>
            {
                opt.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Blog API",
                    Description = "An ASP.NET Core Web API for managing blog items",
                    TermsOfService = new Uri("https://example.com/terms"),
                    Contact = new OpenApiContact
                    {
                        Name = "Example Contact",
                        Url = new Uri("https://example.com/contact")
                    },
                    License = new OpenApiLicense
                    {
                        Name = "Example License",
                        Url = new Uri("https://example.com/license")
                    }
                });

            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(opt =>
                {
                    opt.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
                    opt.RoutePrefix = string.Empty;
                });
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors(option =>
                option.AllowAnyOrigin()
                      .AllowAnyMethod()
                      .AllowAnyHeader()
            );

            app.UseAuthentication();
            app.UseAuthorization();
            app.UseResponseCompression();
            app.UseStaticFiles();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

    }
}