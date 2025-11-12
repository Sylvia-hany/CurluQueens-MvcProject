using CurlyQueens.Data;
using CurlyQueens.Mapping;
using CurlyQueens.Repository;
using CurlyQueens.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
namespace CurlyQueens
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Auto Mapper Configurations
            builder.Services.AddAutoMapper(typeof(MappingProfile));

            // Repository
            builder.Services.AddScoped<IProductRepository, ProductRepository>();
            // Service
            builder.Services.AddScoped<IProductService, ProductService>();
            // Add services to the container.
            builder.Services.AddControllersWithViews();

            //for DbContext
            builder.Services.AddDbContext<MyAppdbcontext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
            builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
                             .AddEntityFrameworkStores<MyAppdbcontext>();
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
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
