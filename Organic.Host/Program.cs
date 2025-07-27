
using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Organic.Application.Behaviors;
using Organic.Application.Command.User;
using Organic.Application.CommandHandler;
using Organic.Domain.Interface;
using Organic.Domain.Interface.UnitOfWorkInterface;
using Organic.Domain.Interface.UserInterfase;
using Organic.Domain.Model;
using Organic.Infrastructure.Context;
using Organic.Infrastructure.DataSeeder;
using Organic.Infrastructure.Middlewares;
using Organic.Infrastructure.Repositories.GenericRepository;
using Organic.Infrastructure.Repositories.UserRepository;
using Organic.Infrastructure.UnitOfWork;

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

            //Behavior
            builder.Services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

            // ثبت MediatR
            builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(RegisterUserCommandHandler).Assembly));

            //command , commandHandler
            builder.Services.AddScoped<IRequestHandler<RegisterUserCommand, string>, RegisterUserCommandHandler>();

            //unit of work
            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

            TypeAdapterConfig<RegisterUserCommand, UserModel>.NewConfig()
                .ConstructUsing(src => new UserModel(
                    src.First_Name,
                    src.Last_Name,
                    src.PhoneNumber,
                    src.Email,
                    src.Password,
                    src.Gender
                ));

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
            }

            app.UseHttpsRedirection();

            app.UseMiddleware<ExceptionHandlingMiddleware>();

            app.UseAuthorization();

            app.UseAuthentication();

            app.MapControllers();

            app.Run();
        }
    }
}
