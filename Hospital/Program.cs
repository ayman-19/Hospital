
using Domain.Models;
using Infrastructure.CashedRepository;
using Infrastructure.DbContext;
using Infrastructure.IRepositories;
using Infrastructure.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Services.IJwtServices;
using Services.IServices;
using Services.JwtServices;
using Services.Services;
using System.Reflection;
using System.Text;

namespace Hospital
{
	/// <summary>
	/// Program
	/// </summary>
	public class Program
	{
		/// <summary>
		/// Main
		/// </summary>
		/// <param name="args"></param>
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

			// Add services to the container.

			builder.Services.AddControllers();
			// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
			builder.Services.AddDbContext<HospitalDbContext>(
				o => o.UseSqlServer(
				builder.Configuration.GetConnectionString("myconnection")));
			builder.Services.AddEndpointsApiExplorer();
			builder.Services.AddIdentity<User, IdentityRole>().AddEntityFrameworkStores<HospitalDbContext>().AddDefaultTokenProviders();
			builder.Services.Configure<Jwt>(builder.Configuration.GetSection("jWTSettings"));
			builder.Services.AddMemoryCache();
			builder.Services.AddScoped<IRepository<Appointment>, Repository<Appointment>>();
			builder.Services.AddScoped<IAccountServices, AccountServices>();
			builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
			builder.Services.AddScoped<IUserRepository, UserRepository>();
			builder.Services.AddScoped<IUserService, UserService>();
			builder.Services.AddScoped<IAppointmentService, AppointmentService>();
			builder.Services.AddScoped<IAppointmentRepository, AppointmentRepository>();
			builder.Services.AddScoped<IDiagonseRepository, DiagonseRepository>();
			builder.Services.AddScoped<IDoctorRepository, DoctorRepository>();
			builder.Services.AddScoped<IDoctorService, DoctorService>();
			builder.Services.AddScoped<IDoctorsHaveSchedulesRepository, DoctorsHaveSchedulesRepository>();
			builder.Services.AddScoped<IDoctorsViewHistoryRepository, DoctorsViewHistoryRepository>();
			builder.Services.AddScoped<IPatientFillHistoryRepository, PatientFillHistoryRepository>();
			builder.Services.AddScoped<IPatientRepository, PatientRepository>();
			builder.Services.AddScoped<IPatientService, PatientService>();
			builder.Services.AddScoped<IRefreshTokenRepository, RefreshTokenRepository>();
			builder.Services.AddScoped<IScheduleRepository, ScheduleRepository>();
			builder.Services.AddScoped<IScheduleService, ScheduleService>();
			builder.Services.AddScoped<IMedicalHistoryRepository, MedicalHistoryRepository>();
			builder.Services.AddScoped<IMedicalHistoryService, MedicalHistoryService>();
			builder.Services.AddScoped<IPatientAttendAppointmentRepository, PatientAttendAppointmentRepository>();

			builder.Services.Decorate<IAppointmentRepository, CasheRepository>();




			builder.Services.AddSwaggerGen(options =>
			{
				options.SwaggerDoc("v1", new OpenApiInfo { Title = "Hospital ", Version = "v1" });
				options.ResolveConflictingActions(apiDescriptions => apiDescriptions.First());
				var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
				var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
				options.IncludeXmlComments(xmlPath);
				options.UseInlineDefinitionsForEnums();
				options.DescribeAllParametersInCamelCase();
				options.InferSecuritySchemes();
			});

			builder.Services.AddSwaggerGen(o =>
			{
				o.AddSecurityDefinition(JwtBearerDefaults.AuthenticationScheme, new OpenApiSecurityScheme
				{
					Description = "JWT Authorization header using the Bearer scheme. \r\n\r\n Enter 'Bearer' [space] and then your token in the text input below.\r\n\r\nExample: \"Bearer 12345abcdef\"",
					Name = "Authorization",
					In = ParameterLocation.Header,
					Type = SecuritySchemeType.ApiKey,
					Scheme = JwtBearerDefaults.AuthenticationScheme,
					BearerFormat = JwtBearerDefaults.AuthenticationScheme,
				});
				o.AddSecurityRequirement(new OpenApiSecurityRequirement
				{
					{
						new OpenApiSecurityScheme
						{
							Reference = new OpenApiReference
							{
								Type = ReferenceType.SecurityScheme,
								Id= JwtBearerDefaults.AuthenticationScheme,
							},
							Name = "Bearer",
							In = ParameterLocation.Header
						},new List<string>()
					}
				});
			});

			builder.Services.AddAuthentication(o =>
			{
				o.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
				o.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
			}).AddJwtBearer(o =>
			{
				o.RequireHttpsMetadata = false;
				o.SaveToken = false;
				o.TokenValidationParameters = new TokenValidationParameters
				{
					ValidateAudience = true,
					ValidateIssuer = true,
					ValidateLifetime = true,
					ValidateIssuerSigningKey = true,
					ValidIssuer = builder.Configuration["jWTSettings:Issuer"],
					ValidAudience = builder.Configuration["jWTSettings:Audience"],
					IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["jWTSettings:Key"])),
					ClockSkew = TimeSpan.Zero
				};
			});




			var app = builder.Build();

			app.UseSwaggerUI();
			app.UseSwagger();

			app.UseHttpsRedirection();
			app.UseAuthentication();
			app.UseAuthorization();


			app.MapControllers();

			app.Run();
		}
	}
}