using AspNet_Api_EfCore.Configurations;
using AspNet_Api_EfCore.Data;
using AspNet_Api_EfCore.Extensions;
using AspNet_Api_EfCore.ValueObject;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

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
                    });
            services.AddRepositories();
            services.AddHandlers();
            services.AddCustomFormat();
            services.AddServices();
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

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

    }
}