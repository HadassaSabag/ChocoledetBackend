using App.DAL.DataContext;
using App.DAL.Interfaces;
using App.DAL.Repositories;
using Microsoft.EntityFrameworkCore;

// הגדרת שם למדיניות ה-CORS שלנו
var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// *** הגדרת מדיניות CORS כאן - הסרנו את מדיניות ברירת המחדל ***
builder.Services.AddCors(options =>
{
    // הגדרת מדיניות CORS ספציפית עבור הפרונט-אנד ב-Netlify
    // זהו המקור היחיד המותר לגישה עם Credentials
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      policy =>
                      {
                          policy.WithOrigins("https://chocoledet.netlify.app") // <-- חשוב מאוד: זהו הדומיין הספציפי של הפרונט-אנד שלך ב-Netlify
                                .AllowAnyHeader()
                                .AllowAnyMethod()
                                .AllowCredentials(); // הוספנו AllowCredentials כדי לאפשר שליחת קוקיז/האדרים של אוטוריזציה
                      });
});
// *** סוף הגדרת CORS ***

builder.Services.AddDbContext<ChocoledetContext>(options =>
{
    // וודאי שחיבור למסד הנתונים מגיע ממשתני סביבה ב-Render ולא רק מ-appsettings.json
    // Render מגדירה את החיבור למסד נתונים כמשתנה סביבה בשם DATABASE_URL
    options.UseSqlServer(builder.Configuration.GetConnectionString("sql"));
});
builder.Services.AddScoped<IUsersRepository, UsersRepository>();
builder.Services.AddScoped<IOrdersRepository, OrdersRepository>();
builder.Services.AddScoped<ICategoriesRepository, CategoriesRepository>();
builder.Services.AddScoped<IOrdersItemsRepository, OrdersItemsRepository>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// *** הפעלת מדיניות ה-CORS הספציפית שלנו (עם השם) ***
// חשוב שזה יהיה לפני UseAuthorization() ו-MapControllers()
app.UseCors(MyAllowSpecificOrigins);
// *** סוף הפעלת CORS ***

app.UseAuthorization();

app.MapControllers();

app.Run();