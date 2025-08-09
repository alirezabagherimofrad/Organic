
using Mapster;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Organic.Application.Behaviors;
using Organic.Application.Command.MessageCommand;
using Organic.Application.Command.User;
using Organic.Application.CommandHandler.UserHandler;
using Organic.Application.DTO;
using Organic.Application.Interface;
using Organic.Application.Service;
using Organic.Domain.Interface;
using Organic.Domain.Interface.UnitOfWorkInterface;
using Organic.Domain.Interface.UserInterfase;
using Organic.Domain.Model.Message;
using Organic.Domain.Model.User;
using Organic.Infrastructure.Context;
using Organic.Infrastructure.DataSeeder;
using Organic.Infrastructure.Middlewares;
using Organic.Infrastructure.Repositories.GenericRepository;
using Organic.Infrastructure.Repositories.ProductCategoryRepository;
using Organic.Infrastructure.Repositories.UserRepository;
using Organic.Infrastructure.Settings;
using Organic.Infrastructure.UnitOfWork;
using System.Text;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Organic.Host
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            // Database Context Settings
            builder.Services.AddDbContext<DataBaseContext>(options =>
             options.UseSqlServer(builder.Configuration.GetConnectionString("Organic")));

            //Repository and IRepository
            builder.Services.AddScoped(typeof(IGenricCommandRepository<>), typeof(GenricCommandRepository<>));
            builder.Services.AddScoped(typeof(IGenricQueryRepository<>), typeof(GenricQueryRepository<>));
            builder.Services.AddScoped<IGetUserQueryRepository, GetUserQueryRepository>();
            builder.Services.AddScoped<IUserQueryRepository, CrudUserRepository>();
            builder.Services.AddScoped<IBasketRepository, BasketRepository>();


            //Behavior
            builder.Services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

            // ثبت MediatR
            builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(RegisterUserCommandHandler).Assembly));

            //command , commandHandler
            builder.Services.AddScoped<IRequestHandler<RegisterUserCommand, string>, RegisterUserCommandHandler>();
            builder.Services.AddScoped<IRequestHandler<LoginUserCommand, LoginResultDto>, LoginUserCommandHandler>();
            builder.Services.AddScoped<IRequestHandler<UplodeUserImageCommand, string>, UplodeUserImageCommandHandler>();

            //unit of work
            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

            builder.Services.AddScoped<IJwtService, JwtService>();


            // Jwt Token Settings
            var jwtSettingsSection = builder.Configuration.GetSection("Jwt");
            builder.Services.Configure<JwtSettings>(jwtSettingsSection);
            var jwtSettings = jwtSettingsSection.Get<JwtSettings>();

            builder.Services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.RequireHttpsMetadata = false;
                options.SaveToken = true;

                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(
                        Encoding.UTF8.GetBytes(jwtSettings.Key)
                    ),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ClockSkew = TimeSpan.Zero
                };
            });

            // Swagger Settings
            builder.Services.AddEndpointsApiExplorer();

            builder.Services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Organic API",
                    Version = "v1"
                });

                // تعریف نوع احراز هویت JWT Bearer
                var jwtSecurityScheme = new OpenApiSecurityScheme
                {
                    Name = "Authorization",
                    Description = "Enter JWT token like: Bearer {your token}",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.Http,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    Reference = new OpenApiReference
                    {
                        Type = ReferenceType.SecurityScheme,
                        Id = "Bearer"
                    }
                };

                options.AddSecurityDefinition("Bearer", jwtSecurityScheme);

                options.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                     {
                       jwtSecurityScheme,
                       Array.Empty<string>()
                     }
                });
            });


            TypeAdapterConfig<RegisterUserCommand, UserModel>.NewConfig()
                .ConstructUsing(src => new UserModel(
                    src.First_Name,
                    src.Last_Name,
                    src.PhoneNumber,
                    src.Email,
                    src.Password,
                    src.Gender
                ));

            TypeAdapterConfig<MessageCommand, MessageModel>.NewConfig()
                .ConstructUsing(src => new MessageModel(
                    src.FullName,
                    src.Title,
                    src.Description,
                    Status.Not_answered,  // مثلا مقدار پیش‌فرض
                    src.Email));

            builder.Services.AddHttpContextAccessor();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            //Seed Data
            using (var scope = app.Services.CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<DataBaseContext>();

                await AdminSeeder.SeedUserAsync(context);

                await ProductCategorySeeder.CategorySeeder(context);
            }
            app.UseStaticFiles();
            app.UseHttpsRedirection();

            app.UseMiddleware<ExceptionHandlingMiddleware>();

            app.UseAuthentication();
            app.UseAuthorization();



            app.MapControllers();

            app.Run();
        }
    }
}
