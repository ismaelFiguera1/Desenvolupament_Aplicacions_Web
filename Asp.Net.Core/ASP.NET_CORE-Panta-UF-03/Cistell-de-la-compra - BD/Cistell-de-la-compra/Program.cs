using Cistell_de_la_compra.Data;
using Microsoft.EntityFrameworkCore;

namespace Cistell_de_la_compra
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

            ServerVersion version = MySqlServerVersion.AutoDetect(connectionString);

            builder.Services.AddDbContext<Context>(options =>
                options.UseMySql(connectionString, version));




            // Configuración para habilitar sesiones
            builder.Services.AddDistributedMemoryCache(); // Cache per la sessio
            builder.Services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(30); // la sessio dura 30min
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
            });



            var app = builder.Build();


            using (var scope = app.Services.CreateScope())
            {

                var dbContext = scope.ServiceProvider.GetRequiredService<Context>();
                dbContext.Database.EnsureDeleted();
                dbContext.Database.EnsureCreated();
            }

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            // Habilitar el middleware de sesión
            app.UseSession();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
