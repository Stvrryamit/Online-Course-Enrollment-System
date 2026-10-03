var builder = WebApplication.CreateBuilder(args);

// Add MVC services.
builder.Services.AddControllersWithViews();

// Add session support.
builder.Services.AddSession();

// Add memory cache support.
builder.Services.AddMemoryCache();

// Add response caching support.
builder.Services.AddResponseCaching();

var app = builder.Build();

// Configure error handling.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}

// Enable HTTPS redirection.
app.UseHttpsRedirection();

// Enable static files.
app.UseStaticFiles();

// Enable response caching.
app.UseResponseCaching();

// Enable routing.
app.UseRouting();

// Enable session.
app.UseSession();

// Enable authorization.
app.UseAuthorization();

// Set the default MVC route.
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Course}/{action=Index}/{id?}");

// Start the application.
app.Run();