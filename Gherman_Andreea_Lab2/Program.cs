using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Gherman_Andreea_Lab2.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();
builder.Services.AddDbContext<Gherman_Andreea_Lab2Context>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Gherman_Andreea_Lab2Context") ?? throw new InvalidOperationException("Connection string 'Gherman_Andreea_Lab2Context' not found.")));

builder.Services.AddDbContext<LibraryIdentityContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Gherman_Andreea_Lab2Context") ?? throw new InvalidOperationException("Connection string 'Gherman_Andreea_Lab2Context' not found.")));

builder.Services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<LibraryIdentityContext>();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapRazorPages();

app.Run();