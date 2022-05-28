using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Tennis4u_API.Data;
using Tennis4u_API.Models.Configs;
using Tennis4u_API.Repositories.Implementations;
using Tennis4u_API.Repositories.Interfaces;
using Tennis4u_API.Services.Implementations;
using Tennis4u_API.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("MssqlDbConnString"));
});

builder.Services.AddAuthentication(opt =>
{
    opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;

}).AddJwtBearer(jwtBearerOptions =>
{
    var jwtConfiguration = builder.Configuration.GetSection("JwtSettings");
    jwtBearerOptions.TokenValidationParameters = new TokenValidationParameters
    {
        ValidIssuer = jwtConfiguration["Issuer"], //should come from configuration builder.Configuration.GetValue<String>("JwtSecurityToken:issuer")
        ValidAudience = jwtConfiguration["Audience"], //should come from configuration builder.Configuration.GetValue<String>("JwtSecurityToken:audience")
        ValidateIssuer = true,   //by who
        ValidateAudience = true, //for whom
        ValidateLifetime = true,
        ClockSkew = TimeSpan.Zero,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtConfiguration["SecretKey"])) //new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["SecretKey"]))
    };

    jwtBearerOptions.Events = new JwtBearerEvents
    {
        OnAuthenticationFailed = tokenContext =>
        {
            if (tokenContext.Exception.GetType() == typeof(SecurityTokenExpiredException))
            {
                tokenContext.Response.Headers.Add("Token-expired", "true");
            }

            return Task.CompletedTask;
        },

        /*        OnTokenValidated = tokenContext =>
                {
                    try
                    {
                        tokenContext.HttpContext.User = tokenContext.Principal ?? throw new InvalidOperationException();
                    }
                    catch
                    {
                        tokenContext.Response.StatusCode = 401;
                        tokenContext.Response.CompleteAsync();
                    }

                    return Task.CompletedTask;
                }*/

    };
});

// Add services to the container.

var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      policy =>
                      {
                          policy.WithOrigins("http://localhost:4200")
                          .AllowCredentials()
                          .AllowAnyMethod()
                          .AllowAnyHeader();
                      });
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<ITennisClubRepository, TennisClubRepository>();
builder.Services.AddScoped<ITournamentRepository, TournamentRepository>();
builder.Services.AddScoped<IReservationRepository, ReservationRepository>();
builder.Services.AddScoped<IClientRepository, ClientRepository>();
builder.Services.AddScoped<IMatchRepository, MatchRepository>();
builder.Services.AddScoped<IWorkerRepository, WorkerRepository>();

builder.Services.AddScoped<IUserAuthenticationService, UserAuthenticationService>();
builder.Services.AddScoped<IJwtService, JwtService>();
builder.Services.AddHttpContextAccessor();

builder.Services.Configure<JwtConfigModel>(builder.Configuration.GetSection("JwtSettings"));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(MyAllowSpecificOrigins);

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();