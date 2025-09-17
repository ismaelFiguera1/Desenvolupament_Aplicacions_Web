using Microsoft.EntityFrameworkCore;
using TaskAplication.Data;

namespace TaskAplication
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


            builder.Services.AddDbContext<ApplicationContext>(options =>
                            options.UseMySql(connectionString, version));


            var app = builder.Build();



            using (var scope = app.Services.CreateScope())
            {

                var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationContext>();
                dbContext.Database.EnsureDeleted();
                dbContext.Database.EnsureCreated();
            }




            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
