using App.BL.Interfaces; // Added for service interfaces
using App.BL.Services;    // Added for service implementations
using App.DAL.DataContext;
using App.DAL.Interfaces; // Added for repository interfaces
using App.DAL.Repositories;
using Microsoft.EntityFrameworkCore;
using Npgsql.EntityFrameworkCore.PostgreSQL;


// Define the name for our CORS policy
var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers(); // Enables API controllers
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// *** CORS Configuration - Only the specific policy is defined and used ***
builder.Services.AddCors(options =>
{
    // Define a specific CORS policy for the Netlify frontend
    // This is the only origin allowed to access with credentials
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      policy =>
                      {
                          // <-- חשוב: ודא שזהו הדומיין המדויק של הפרונטאנד שלך ב-Netlify, כולל HTTP או HTTPS
                          // בצילום המסך הקודם שלך ראיתי http://chocoledelet.netlify.app,
                          // אם האתר שלך ב-Netlify עבר ל-HTTPS, אז https:// זה נכון.
                          // אם הוא עדיין HTTP, שנה ל-http://
                          policy.WithOrigins("https://chocoledet.netlify.app")
                                .AllowAnyHeader()
                                .AllowAnyMethod()
                                .AllowCredentials(); // Allow cookies/authorization headers
                      });
});
// *** End CORS Configuration ***

builder.Services.AddDbContext<ChocoledetContext>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("sql"));
});

// *** Dependency Injection Registrations for Repositories and Services ***
// Register Repositories
builder.Services.AddScoped<IUsersRepository, UsersRepository>();
builder.Services.AddScoped<IOrdersRepository, OrdersRepository>();
builder.Services.AddScoped<ICategoriesRepository, CategoriesRepository>();
builder.Services.AddScoped<IOrdersItemsRepository, OrdersItemsRepository>();
// Assuming you also have a ProductsRepository based on your frontend fetching products
builder.Services.AddScoped<IProductsRepository, ProductsRepository>();

// Register Services (based on common patterns and your previous error for IUsersService)
// This ensures that your controllers can receive instances of these services
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IOrderService, OrderService>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<IOrderItemService, OrderItemService>();
// Assuming you also have a ProductService
builder.Services.AddScoped<IProductService, ProductService>();
// *** End Dependency Injection Registrations ***


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// *** הוסף את השורה הזו כאן! ***
// חשוב מאוד: UseRouting חייב להיות לפני UseCors
app.UseRouting();
// ****************************

// *** Activate our specific CORS policy (by name) ***
// IMPORTANT: This must be placed after app.UseRouting() and before app.UseAuthorization() and app.MapControllers()
app.UseCors(MyAllowSpecificOrigins);
// *** End CORS Activation ***

app.UseAuthorization();

app.MapControllers(); // Maps controller routes (e.g., /api/users, /api/products)

app.Run();