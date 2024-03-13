using Microsoft.EntityFrameworkCore;
using prova_eclipseworks.Data;

namespace prova_eclipseworks.Service;

public static class DatabaseManagementService
{
    public static void MigrationInitialisation(this IApplicationBuilder app)
    {
        using (var service = app.ApplicationServices.CreateScope())
        {
            var serviceDb = service.ServiceProvider.GetService<ProvaEclipseworksDBContext>();
            serviceDb.Database.Migrate();
        }
    }
}


