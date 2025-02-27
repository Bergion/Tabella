using Cabinet.API.Infrastructure;
using Cabinet.API.Managers;
using Cabinet.API.Services;
using Cabinet.API.Services.Abstractions;
using Cabinet.Storage;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;


namespace Cabinet.API
{
	public class Startup
	{
		private readonly IWebHostEnvironment _enviroment;

		public Startup(IConfiguration configuration,
			IWebHostEnvironment enviroment)
		{
			Configuration = configuration;
			_enviroment = enviroment;
		}

		public IConfiguration Configuration { get; }


		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
		{
			services.AddDbContext<CabinetContext>(options =>
				options.UseSqlServer(Configuration.GetConnectionString("DevelopmentConnection")));

			services.AddFileStorage(options =>
			{
				options.Configure(Configuration.GetSection("DevelopmentStorage").Get<StorageConfiguration>());
			});

			services.AddTransient<DocumentManager>();
			services.AddTransient<IDocumentService, DocumentService>();

			services.AddCors(options =>
			{
				options.AddPolicy("CorsPolicy",
					builder =>
					builder
					.SetIsOriginAllowed((host) => true)
					.AllowAnyMethod()
					.AllowAnyHeader()
					.AllowCredentials());
			});
			services.AddGrpc(options => options.EnableDetailedErrors = true);
			services.AddControllers();
			services.AddSwaggerGen(c =>
			{
				c.SwaggerDoc("v1", new OpenApiInfo { Title = "Cabinet.API", Version = "v1" });
			});
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
				app.UseSwagger();
				app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Cabinet.API v1"));
			}
			app.UseHttpsRedirection();

			app.UseStaticFiles();

			app.UseRouting();

			app.UseAuthorization();
			app.UseCors("CorsPolicy");

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllers();
			});
		}
	}
}
