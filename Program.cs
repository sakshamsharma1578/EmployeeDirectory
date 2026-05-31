using AddressBookApp.BM;
using AddressBookApp.BM.ITF;
using AddressBookApp.DL;
using AddressBookApp.DL.ITF;

var builder = WebApplication.CreateBuilder(args);

string conn = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddScoped<IAddressDL>(_ => new AddressDL(conn));
builder.Services.AddScoped<IAddressBM, AddressBM>();

builder.Services.AddControllersWithViews();

var app = builder.Build();

// Error handling
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}

// ❗ Serve static files FIRST
app.UseStaticFiles();

// Routing AFTER static files
app.UseRouting();

app.UseAuthorization();

// MVC routes
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Address}/{action=Index}/{id?}");

app.Run();
