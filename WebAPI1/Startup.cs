namespace WebAPI1
{
    using Business.Abstract;
    using Business.Concrete;
    using DataAccess.Abstract;
    using DataAccess.Concrete.Entity_Framework;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.Extensions.DependencyInjection;

    public class Startup
    {
        // Servisleri kaydetme
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddSingleton<IProductService, ProductManager>();//Biri constructorda IPorductService isterse ona arka planda ProductManager new'i ver.
                                                                     //Arka planda newleyip bize veriyor IoC.
            services.AddSingleton<IProductDal, EfProductDal>();
        }

        // Middleware ve uygulama yapılandırma
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }

}
