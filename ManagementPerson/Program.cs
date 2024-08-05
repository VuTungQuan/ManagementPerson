using Microsoft.EntityFrameworkCore;

namespace ManagementPerson
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddRazorPages();
            builder.Services.AddDbContext<MyDbContext>(options =>
               options.UseSqlServer(builder.Configuration.GetConnectionString("MyDb")));

            var app = builder.Build();

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

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapRazorPages();
                endpoints.MapGet("/routes", async context =>
                {
                    var routes = context.RequestServices.GetRequiredService<EndpointDataSource>();
                    await context.Response.WriteAsync(string.Join("\n", routes.Endpoints.Select(e => e.DisplayName)));
                });
            });

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=People}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
