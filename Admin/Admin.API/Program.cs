using Admin.API.IoC;
using Admin.Application;
using Admin.Infrastructure;

namespace Admin.API;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        {
            builder.Services
                .AddPresentation()
                .AddApplication()
                .AddInfrastructure(builder.Configuration)
                .AddPersistence();
        }
        
        var app = builder.Build();
        {
            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
                DevelopContainers.Setup(app);
            }
            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.MapControllers();
            app.Run();
        }
    }
}
