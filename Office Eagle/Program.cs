using Microsoft.EntityFrameworkCore;
using Office_Eagle.AutoMapper;
using Office_Eagle.Data;
using Office_Eagle.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<OfficeEagleDbContext>(
    options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
);

// log that the database is being created

// jwt authentication
// builder.Services
//     .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
//     .AddJwtBearer(options =>
//     {
//         options.TokenValidationParameters = new TokenValidationParameters
//         {
//             ValidateIssuer = true,
//             ValidateAudience = true,
//             ValidateLifetime = true,
//             ValidateIssuerSigningKey = true,
//             ValidIssuer = builder.Configuration["AppSettings:Key"],
//             ValidAudience = builder.Configuration["AppSettings:Key"],
//             IssuerSigningKey = new SymmetricSecurityKey(
//                 Encoding.UTF8.GetBytes(builder.Configuration["AppSettings:Key"])
//             ),
//             ClockSkew = TimeSpan.Zero,
//             // Read the token expiration duration from configuration
//             TokenDecryptionKey = new SymmetricSecurityKey(
//                 Encoding.UTF8.GetBytes(builder.Configuration["AppSettings:Key"])
//             )
//         };
// });

//cors
// builder.Services.AddCors(options =>
// {
//     options.AddPolicy(
//         "CorsPolicy",
//         builder =>
//         {
//             builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
//         }
//     );
// });

// dependency injection
builder.Services.AddTransient<IEmployeeRepository, DbEmployeeRepository>();
builder.Services.AddAutoMapper(typeof(MappingProfile));

var app = builder.Build();
app.UseStaticFiles();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options => options.InjectStylesheet("custom.css"));
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
