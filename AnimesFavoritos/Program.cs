using AnimesFavoritos.Services;
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

builder.Services.AddSession();
builder.Services.AddHttpContextAccessor();
builder.Services.AddSingleton<IAnimesService, AnimeService>();


var app = builder.Build();
if (!app.Environment.IsDevelopment())
{
app.UseExceptionHandler("/Home/Error");

app.UseHsts();
}
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();
app.UseSession();
app.MapControllerRoute(
name: "default",
pattern: "{controller=Home}/{action=Index}/{id?}");
app.Run();