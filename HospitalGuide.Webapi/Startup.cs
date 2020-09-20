using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using HospitalGuide.Webapi.Data.Abstract;
using HospitalGuide.Webapi.Data.Concrete.EF;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Routing.Template;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Swashbuckle.AspNetCore.Swagger;

namespace HospitalGuide.Webapi
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
            var key = Encoding.ASCII.GetBytes(Configuration.GetSection("AppSettings:Token").Value);
            
            services.AddDbContext<DataContext>(Options =>
            Options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            services.AddAutoMapper();
            //swagger api endpoint noktalarını görmek için
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v2", new Info { Title = "My Appointment System API", Version = "v2",
                        Contact = new Contact
                        {
                            Name = "Burak Keleş",
                            Email = "burakkeles@stu.aydin.edu.tr"
                            
                        },
                        Description = "Burak KELEŞ"

                    }
                    
               );
             
            });
            services.AddMvc().AddJsonOptions(Options=>Options.SerializerSettings.ReferenceLoopHandling=Newtonsoft.Json.ReferenceLoopHandling.Ignore);
            //Loop Kesici Data icinde.

            services.AddCors();//Dısardaki proje ve Tarayıcıya anlasma saglıyor.
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<ICountryRepository, CountryRepository>();
            services.AddScoped<IClinicsRepository, ClinicRepository>();
            services.AddScoped<IAppointmentRepository, AppointmentRepository>();
            services.AddScoped<IHospitalRateRepository, HospitalRateRepository>();
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {

                app.UseDeveloperExceptionPage();
                

            }
            var policyCollection = new HeaderPolicyCollection().AddDefaultSecurityHeaders().AddCustomHeader("Access-Control-Allow-Origin", "*");
       
            app.UseSecurityHeaders(policyCollection);
            app.UseCors(x => x.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin().AllowCredentials());
            app.UseAuthentication();

            //swagger ayar
            app.UseDefaultFiles();
            app.UseStaticFiles();
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v2/swagger.json", "v2");
                

            });

            app.UseMvc();
        
        }
    }
}
