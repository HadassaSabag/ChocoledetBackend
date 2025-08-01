using App.BL.Interfaces;
using App.BL.Services;
using App.DAL.DataContext;
using App.DAL.Interfaces;
using App.DAL.Repositories;
using Microsoft.EntityFrameworkCore;

// הגדרת שם למדיניות ה-CORS שלנו
var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// *** שינוי וודאי את הגדרות CORS כאן ***
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins, // שימוש בשם המדיניות
                      policy =>
                      {
                          policy.WithOrigins("https://chocoledet.netlify.app") // <-- חשוב מאוד: זה הדומיין הספציפי של הפרונט-אנד שלך ב-Netlify
                                .AllowAnyHeader()
                                .AllowAnyMethod()
                                .AllowCredentials(); // הוספנו AllowCredentials כדי לאפשר שליחת קוקיז/האדרים של אוטוריזציה
                      });
});
// *** סוף שינויי CORS ***

builder.Services.AddDbContext<ChocoledetContext>(options =>
{
    // וודאי שהחיבור למסד הנתונים מגיע ממשתני סביבה ב-Render ולא רק מ-appsettings.json
    // Render מגדירה את החיבור למסד נתונים כמשתנה סביבה בשם DATABASE_URL
    // נצטרך להתאים את זה ל-SQL Server אם החיבור string הוא שונה (לרוב עם SqlConnectionStringBuilder)
    // נניח ש-builder.Configuration.GetConnectionString("sql") עובד ב-Render דרך משתני סביבה
    options.UseSqlServer(builder.Configuration.GetConnectionString("sql"));
});
builder.Services.AddScoped<IUsersRepository, UsersRepository>();
builder.Services.AddScoped<IOrdersRepository, OrdersRepository>();
builder.Services.AddScoped<ICategoriesRepository, CategoriesRepository>();
builder.Services.AddScoped<IOrdersItemsRepository, OrdersItemsRepository>();
builder.Services.AddScoped<IProductsRepository, ProductsRepository>();

builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IOrderService, OrderService>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<IOrderItemService, OrderItemService>();
builder.Services.AddScoped<IProductService, ProductService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// *** הפעלת מדיניות ה-CORS הספציפית שלנו (עם השם) ***
app.UseCors(MyAllowSpecificOrigins); // חשוב שזה יהיה לפני UseAuthorization() ו-MapControllers()
// *** סוף הפעלת CORS ***

app.UseAuthorization();

app.MapControllers();

app.Run();