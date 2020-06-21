namespace API
{
    using API.Models;
    using AutoMapper;
    using Base.Datos.Clases.DAL;
    using Base.Datos.Contexto;
    using Base.Datos.Contexto.Entidades;
    using Base.IC.Clases;
    using Base.IC.DTO.EntidadesRepositorio;
    using Base.Negocio.Clases.BL;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;

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
            services.AddAutoMapper(configuration =>
            {
                //Mapper Paciente
                configuration.CreateMap<Respuesta<PacienteCO>, Respuesta<IPacienteDTO>>().ReverseMap();
                configuration.CreateMap<PacienteCO, IPacienteDTO>().ReverseMap();
                configuration.CreateMap<Paciente, IPacienteDTO>().ReverseMap();
                //Maper Doctor
                configuration.CreateMap<Respuesta<DoctorCO>, Respuesta<IDoctorDTO>>().ReverseMap();
                configuration.CreateMap<DoctorCO, IDoctorDTO>().ReverseMap();
                configuration.CreateMap<Doctor, IDoctorDTO>().ReverseMap();
                //Maper Especilidad
                configuration.CreateMap<Respuesta<EspecialidadCO>, Respuesta<IEspecialidadDTO>>().ReverseMap();
                configuration.CreateMap<EspecialidadCO, IEspecialidadDTO>().ReverseMap();
                configuration.CreateMap<Especialidad, IEspecialidadDTO>().ReverseMap();
            }, typeof(Startup));
            //Paciente
            services.AddScoped<PacienteDAL>();
            services.AddScoped<PacienteBL>();
            //Doctor
            services.AddScoped<DoctorDAL>();
            services.AddScoped<DoctorBL>();
            //Especialidad
            services.AddScoped<EspecialidadDAL>();
            services.AddScoped<EspecialidadBL>();

            services.AddDbContext<Context>(options => options.UseSqlServer(Configuration.GetConnectionString("AppConnection")));
            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}