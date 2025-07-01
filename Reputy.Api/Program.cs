using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Reputy.Api.Filters;
using Reputy.Api.Middleware;
using Reputy.Application.DatabaseContext;
using Reputy.Application.DependencyInjection;
using Reputy.Infrastructure.DependencyInjection;
using Reputy.Infrastructure.Mapper;
using System.Text;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Logging.ClearProviders();
    builder.Logging.AddConsole();

    builder.Services.AddControllers(options => options.Filters.Add<ErrorHandlingFilterAttribute>());

    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen(option =>
    {
        option.SwaggerDoc("v1", new OpenApiInfo { Title = "Demo API", Version = "v1" });
        option.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
        {
            In = ParameterLocation.Header,
            Description = "Please enter a valid token",
            Name = "Authorization",
            Type = SecuritySchemeType.Http,
            BearerFormat = "JWT",
            Scheme = "Bearer"
        });
        option.AddSecurityRequirement(new OpenApiSecurityRequirement
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
                        new string[]{}
                    }
                });
    });


    builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
           .AddJwtBearer(options =>
           {
               options.TokenValidationParameters = new TokenValidationParameters
               {
                   ValidateIssuer = true,
                   ValidateAudience = true,
                   ValidateLifetime = true,
                   ValidateIssuerSigningKey = true,
                   ValidIssuer = builder.Configuration["JwtSettings:Issuer"],
                   ValidAudience = builder.Configuration["JwtSettings:Audience"],
                   IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(
                       builder.Configuration["JwtSettings:SecretKey"]))
               };
           });

    builder.Services
            .AddApplication()
            .AddInfrastructure(builder.Configuration);

    builder.Services
       .AddAutoMapper(typeof(AdvertisementMapperProfile))
       .AddAutoMapper(typeof(ReferenceMapperProfile));

    builder.Services.AddDbContext<ReputyContext>(options =>
               options.UseSqlServer(builder.Configuration.GetConnectionString("sqlConnection")));

    builder.Services.AddCors(options =>
    {
        options.AddDefaultPolicy(
            builder =>
            {
                builder.AllowAnyOrigin()
                    .SetIsOriginAllowedToAllowWildcardSubdomains()
                    .AllowAnyHeader()
                    .AllowAnyMethod();
            });
    });
}

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseCors();

app.UseMiddleware<ErrorHandlingMiddleware>();

app.Run();
