using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Swashbuckle.AspNetCore.Swagger;
using Microsoft.Extensions.Hosting;
using Order.BusinessLayer.Abstract_Interface;
using Microsoft.AspNetCore.Http;
using Order_DataAccessLayer.Model;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using System.IO;

namespace Order.API
{
	public class Startup
	{
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		// This method gets called by the runtime. Use this method to add services to the container.
		// For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
		public void ConfigureServices(IServiceCollection services)
		{
			services.AddDbContext<OrderContext>(options =>
			options.UseSqlServer(Configuration.GetConnectionString("OrderDb")));

			services.AddMvc(options => options.EnableEndpointRouting = false);
			services.AddOptions();
			services.AddScoped<ICustomer, BusinessLayer.Concrete_Implementation.Customer>();
			services.AddScoped<IOrder, BusinessLayer.Concrete_Implementation.Order>();
			services.AddScoped<ICustomerOrder, BusinessLayer.Concrete_Implementation.CustomerOrder>();

			services.AddSwaggerGen(option =>
			{
				option.SwaggerDoc("v1",
					new Microsoft.OpenApi.Models.OpenApiInfo
					{
						Title = "Swagger Order API",
						Description = "Test all APIs through swagger",
						Version = "v1"
					});
			});
			services.AddCors();
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}
			else
			{
				app.UseHsts();
			}
			app.UseSwagger();

			app.UseSwaggerUI(c =>
			{
				c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
			});

			app.UseCors(builder =>
			builder.WithOrigins("http://localhost:4200").AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());

			app.UseHttpsRedirection();
			app.UseMvc();
		}	
	}
}
