using AspNet_Api_EfCore.Configurations;
using AspNet_Api_EfCore.Data;
using AspNet_Api_EfCore.Extensions;
using AspNet_Api_EfCore.Services;
using AspNet_Api_EfCore.Services.Interfaces;
using AspNet_Api_EfCore.ValueObjects;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
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

            services.AddAuthentication(opt => {
                opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;

            }).AddJwtBearer(opt => {
                opt.RequireHttpsMetadata = false;
                opt.SaveToken = true;
                opt.TokenValidationParameters = new TokenValidationParameters {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });

            services.AddControllers()
                    .ConfigureApiBehaviorOptions(opt => {
                        opt.SuppressModelStateInvalidFilter = true;
                    })
                    .AddJsonOptions(opt => {
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
            services.AddDbContext<BlogDataContext>();

            services.AddAutoMapper(typeof(Startup));
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseCors(option =>
                option.AllowAnyOrigin()
                      .AllowAnyMethod()
                      .AllowAnyHeader()
            );

            app.UseAuthentication();
            app.UseAuthorization();
            app.UseStaticFiles();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

    }
}