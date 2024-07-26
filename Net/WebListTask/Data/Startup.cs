using WebListTask.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

public class Startup
{
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddDbContext<TareasContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("TareasContext")));
        services.AddRazorPages();
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        // configuración existente
    }
}
