using DigitalGraduate.Data.Context;
using DigitalGraduate.Data.DAL;
using DigitalGraduate.Data.DAL.CertificateApplication;
using DigitalGraduate.Data.DAL.Certification;
using DigitalGraduate.Data.DAL.Dissertation;
using DigitalGraduate.Data.DAL.EntranceTest;
using DigitalGraduate.Data.DAL.File;
using DigitalGraduate.Data.DAL.Grant;
using DigitalGraduate.Data.DAL.Patent;
using DigitalGraduate.Data.DAL.Publication;
using DigitalGraduate.Data.DAL.ScientificCompetition;
using DigitalGraduate.Data.DAL.ScientificConference;
using DigitalGraduate.Data.DAL.Student;
using DigitalGraduate.Data.Models.Identity;
using DigitalGraduate.Services;
using DigitalGraduate.Utils.JsonConverters;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

var builder = WebApplication.CreateBuilder(args);
var config = builder.Configuration;

// Db connections
var testDbConnString = builder.Configuration.GetConnectionString("TestDbConnection");
var identityDbConnString = builder.Configuration.GetConnectionString("IdentityDbConnection");

// Add services to the container.

builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.Converters.Add(new JsonToByteArrayConverter());
});
builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsForTests", policy =>
    {
        policy
        .WithOrigins("http://localhost:3000")
        .AllowAnyMethod()
        .AllowAnyHeader();
    });
});

builder.Services.AddIdentity<ApiUser, IdentityRole>(options =>
{
    options.Password.RequireDigit = true;
    options.Password.RequireLowercase = true;
    options.Password.RequireNonAlphanumeric = true;
    options.Password.RequireUppercase = true;
    options.Password.RequiredLength = 8;
})
.AddEntityFrameworkStores<IdentityDbContext>();

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.SaveToken = true;
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidIssuer = config["JwtSettings:Issuer"],
        ValidAudience = config["JwtSettings:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["JwtSettings:Key"]!)),
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true
    };
});

builder.Services.AddTransient<AuthenticationService>();
builder.Services.AddAuthorization();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
    options.UseNpgsql(testDbConnString).EnableSensitiveDataLogging();
}, ServiceLifetime.Transient, ServiceLifetime.Transient);

builder.Services.AddDbContext<IdentityDbContext>(options =>
{
    options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
    options.UseNpgsql(identityDbConnString).EnableSensitiveDataLogging();
}, ServiceLifetime.Transient, ServiceLifetime.Transient);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "¬ведите валидный токен",
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        BearerFormat = "JWT",
        Scheme = "Bearer"
    });
    options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type=ReferenceType.SecurityScheme,
                    Id="Bearer"
                }
            },
            Array.Empty<string>()
        }
    });
});

builder.Services.AddHttpContextAccessor();

// Repositories register
builder.Services.AddScoped<IRepository<Student>, StudentRepository>();
builder.Services.AddScoped<IRepository<EntranceTest>, EntranceTestRepository>();
builder.Services.AddScoped<IRepository<Publication>, PublicationRepository>();
builder.Services.AddScoped<IRepository<FileInstance>, FileRepository>();
builder.Services.AddScoped<IRepository<CertificateApplication>, CertificateApplicationRepository>();
builder.Services.AddScoped<IRepository<Patent>, PatentRepository>();
builder.Services.AddScoped<IRepository<Grant>, GrantRepository>();
builder.Services.AddScoped<IRepository<ScientificCompetition>, ScientificCompetitionRepository>();
builder.Services.AddScoped<IRepository<ScientificConference>, ScientificConferenceRepository>();
builder.Services.AddScoped<IRepository<Certification>, CertificationRepository>();
builder.Services.AddScoped<IRepository<Dissertation>, DissertationRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseSwagger();
app.UseSwaggerUI();

using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
    dbContext.Database.Migrate();
}

//app.UseHttpsRedirection();

app.UseCors("CorsForTests");

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
