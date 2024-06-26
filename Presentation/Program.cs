using DataAccess.AboutRepository.Concrete;
using DataAccess.Context;
using DataAccess.Repositories.Abstract;
using DataAccess.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using Presentation.Middlewares;
using Business.MappingProfiles;
using Business.Services.Abstraction;
using Business.Services.Concered;
using DocumentFormat.OpenXml.Office2016.Drawing.ChartDrawing;
using Microsoft.OpenApi.Models;
using DataAccess.Repositories.Concrete;
using Common.Entities;

var builder = WebApplication.CreateBuilder(args);






/*Logger log = new LoggerConfiguration()
      .WriteTo.Seq("http://localhost:5341")
      .WriteTo.File("C:\\Users\\ROG\\Desktop\\Loge\\ApiLog-.log", rollingInterval: RollingInterval.Day)
      .Enrich.FromLogContext()
      .MinimumLevel.Information()
      .CreateLogger();

builder.Host.UseSerilog(log);*/


// Add services to the container.





builder.Services.AddControllers();




// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

//Summarylerin dusmesi ucun swaggere
builder.Services.AddSwaggerGen(options =>
{
    options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, "Presentation.xml"));
});

builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<AppDbContext>(x => x.UseSqlServer(builder.Configuration.GetConnectionString("Default"), x => x.MigrationsAssembly("DataAccess")));


/*
builder.Services.AddSwaggerGen(options =>
{
    options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, "Presentation.xml"));

    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "JWTToken_Auth_API",
        Version = "v1"
    });



    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
    {
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        Scheme = JwtBearerDefaults.AuthenticationScheme,
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "JWT Authorization header using the Bearer scheme. \r\n\r\n Enter 'Bearer' [space] and then your token in the text input below.\r\n\r\nExample: \"Bearer 1safsfsdfdfd\"",
    });
    options.AddSecurityRequirement(new OpenApiSecurityRequirement {
        {
            new OpenApiSecurityScheme {
                Reference = new OpenApiReference {
                    Type = ReferenceType.SecurityScheme,
                        Id = "Bearer"
                }
            },
            new string[] {}
        }
    });
});





builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
})
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidIssuer = builder.Configuration["JWT:Issuer"],
            ValidateAudience = true,
            ValidAudience = builder.Configuration["Jwt:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JWT:Secret"]))
        };
    });
*/


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

builder.Services.Configure<RouteOptions>(x =>
{
    x.LowercaseUrls = true;
});

builder.Services.AddDbContext<AppDbContext>(x => x.UseSqlServer(builder.Configuration.GetConnectionString("Default"), x => x.MigrationsAssembly("DataAccess")));
/*
builder.Services.AddIdentity<User, IdentityRole>(options =>
{
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireDigit = false;
    options.Password.RequireUppercase = false;
    options.Password.RequireLowercase = false;
    options.Password.RequiredLength = 0;
    options.Password.RequiredUniqueChars = 0;
})
    .AddEntityFrameworkStores<AppDbContext>();*/




builder.Services.AddCors(p => p.AddDefaultPolicy(builder =>
{
    builder.WithOrigins("https://localhost:44395/");
    builder.AllowAnyMethod();
    builder.AllowAnyHeader();

}));





/*

builder.Services.Configure<EmailSettings>(builder.Configuration.GetSection("EmailSettings"));
builder.Services.AddTransient<IEmailService, EmailService>();*/



#region Repositories

builder.Services.AddScoped<IAboutRepository , AboutRepository>();
builder.Services.AddScoped<ITagRepository , TagRepository>();
builder.Services.AddScoped<IBlogRepository, BlogRepository>();
builder.Services.AddScoped<IOpeningHoursRepository , OpeningHoursRepository>();
builder.Services.AddScoped<ILocationRepository, LocationRepository>();
builder.Services.AddScoped<IMenuRepository, MenuRepository>();
builder.Services.AddScoped<ISubMenuRepository, SubMenuRepository>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();




#endregion



#region UnitOfWork

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

#endregion



#region Services
builder.Services.AddScoped<IAboutService, AboutService>();
builder.Services.AddScoped<ITagService, TagService>();
builder.Services.AddScoped<IBlogService, BlogService>();
builder.Services.AddScoped<IOpeningHoursService, OpeningHoursService>();
builder.Services.AddScoped<ILocationService, LocationService>();
builder.Services.AddScoped<ISubMenuService, SubMenuService>();
builder.Services.AddScoped<IMenuService, MenuService>();
builder.Services.AddScoped<IProductService, ProductService>();


#endregion




#region Mapping

builder.Services.AddAutoMapper(x =>
{
    x.AddProfile(new AboutMappingProfile());
    x.AddProfile(new TagMappingProfile());
    x.AddProfile<BlogMappingProfile>();
    x.AddProfile<OpeningHoursMappingProfile>();
    x.AddProfile<LocationsMappingProfile>();
    x.AddProfile<MenuMappingProfile>();
    x.AddProfile<SubMenuMappingProfile>();
    x.AddProfile<ProductMappingProfile>();


});
#endregion






var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();

}







app.UseHttpsRedirection();
app.UseCors("https://localhost:44395/");
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.UseMiddleware<CustomExceptionMiddleware>();

app.Run();
