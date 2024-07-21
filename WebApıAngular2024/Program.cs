using Autofac;
using Autofac.Extensions.DependencyInjection;
using Business.DepedncyResolvers.Autofac;
using Core.DependencyResolvers;
using Core.Extensions;
using Core.Utilites.IOC;
using Core.Utilites.Security.Encrypiton;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

namespace WebApıAngular2024
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            var tokenOptions = builder.Configuration.GetSection("TokenOptions").Get<Core.Utilites.Security.JWT.TokenOptions>();

            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidIssuer = tokenOptions.Issuer,
                        ValidAudience = tokenOptions.Audience,
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = SecurityKeyHelper.CreateSecurityKey(tokenOptions.SecurityKey)
                    };
                });
            builder.Services.AddAddDependencyResolvers(new ICoreModule[]
            {
                new CoreModule()
            });

            //AddSingleton metodu, ASP.NET Core bağımlılık enjeksiyon (DI) konteynerine bir servis kaydetmek için kullanılır.
            //builder.Services.AddSingleton<IProductService, ProductManager>();
            //builder.Services.AddSingleton<IProductDal, EFProductDal>();

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Host
                .UseServiceProviderFactory(new AutofacServiceProviderFactory())
                .ConfigureContainer< ContainerBuilder >(builder =>
                {
                    builder.RegisterModule(new AutofacBusinessModul());
                });
          
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            

            app.UseHttpsRedirection();

            app.UseAuthentication();

            app.UseAuthorization();

            
            app.MapControllers();

            app.Run();
        }
    }
}
