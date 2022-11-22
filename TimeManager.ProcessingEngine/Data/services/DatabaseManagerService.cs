using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using TimeManager.ProcessingEngine.Data;

/*
 
-- IMPORTANT NOTE --
To make migration initialization works successfully these packages 
must have the same versions : 

Microsoft.EntityFrameworkCore
Microsoft.AspNetCore.Identity.EntityFrameworkCore
Microsoft.EntityFrameworkCore.Design
Microsoft.EntityFrameworkCore.SqlServer

*/

namespace TimeManager.ProcessingEngine.Data.Services
{
    public static class DatabaseManagerService
    {

        public static void MigrationInitialization(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                serviceScope.ServiceProvider.GetService<DataContext>().Database.Migrate();
            }
        }
    }
}
