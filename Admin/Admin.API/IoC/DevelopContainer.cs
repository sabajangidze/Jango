using Admin.Infrastructure.Data;
using Admin.Infrastructure;
using Jango.Admin;

namespace Admin.API.IoC
{
    public static class DevelopContainers
    {
        public static void Setup(IHost host)
        {
            CreateDbIfNotExists(host);
        }

        private static void CreateDbIfNotExists(IHost host)
        {
            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                try
                {
                    var context = services.GetRequiredService<ApplicationDbContext>();
                    DbInitialize.Initialize(context);
                }
                catch (Exception ex)
                {
                    var logger = services.GetRequiredService<ILogger<Program>>();
                    logger.LogError(ex, "An error occurred creating the DB.");
                }
            }
        }
    }
}
