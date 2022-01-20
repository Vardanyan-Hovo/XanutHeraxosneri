using Microsoft.EntityFrameworkCore;
using XanutHeraxosneri.Data;
using XanutHeraxosneri.Data.function;
using XanutHeraxosneri.Data.Repositorys;
using XanutHeraxosneri.Models;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(
    builder.Configuration.GetConnectionString("DefaultConnections")
    ));

builder.Services.AddScoped<ICategory, RepositoryCategory>();
builder.Services.AddScoped<ICart, RepositoryCart>();
builder.Services.AddScoped<Iapranq, RepositoryApranq>();

builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.AddScoped(c => Item.Items(c));

builder.Services.AddRazorPages().AddRazorRuntimeCompilation();
builder.Services.AddMvc();
builder.Services.AddSession();
builder.Services.AddMemoryCache();


// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();
using (var scope = app.Services.CreateScope())
{
    ApplicationDbContext db = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
    DbStatic.complete(db);
}
app.UseSession();
// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthorization();


app.MapControllerRoute(
    name: "Template",
    pattern: "{controller=Repository}/{action=Search}/{search}"
    );

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}"
    );



app.Run();

