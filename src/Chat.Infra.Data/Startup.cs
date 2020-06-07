using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace Chat.Infra.Data
{
    public static class Startup
    {
        public static void RunMigration<T>(IApplicationBuilder app) where T : DbContext
        {
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<T>();
                context.Database.SetCommandTimeout(3 * 1000);
                context.Database.Migrate();
            }
        }
    }
}
