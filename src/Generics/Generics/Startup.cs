using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Generics
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<Data.ApplicationDbContext>(options =>
                options.UseNpgsql(Configuration.GetConnectionString("DefaultConnection")));

            services.AddIdentity<Models.ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<Data.ApplicationDbContext>()
                .AddDefaultTokenProviders();

            // Add application services.
            services.AddTransient<Services.Email.IEmailSender, Services.Email.EmailSender>();

            // Add generic service
            services.AddScoped(typeof(Services.Generic.IGenericService<>), typeof(Services.Generic.GenericService<>));

            // Add specific service from that's extends from generic service
            AddCustomServices(services);

            services.AddMvc()
                .AddJsonOptions(
                    options => options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
                );
        }

        private void AddCustomServices(IServiceCollection services)
        {
            services.AddScoped<Services.Category.ICategoryService, Services.Category.CategoryService>();
            services.AddScoped<Services.Product.IProductService, Services.Product.ProductService>();
            services.AddScoped<Services.Supplier.ISupplierService, Services.Supplier.SupplierService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseBrowserLink();
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseAuthentication();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
