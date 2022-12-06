using Blazored.Modal;
using Blazored.Toast;
using JanGym.Authentication;
using JanGym.Data;
using JanGym.Data.Repository;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Server;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MudBlazor.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddAuthenticationCore();
var connectionString = builder.Configuration.GetConnectionString("appcon");
builder.Services.AddBlazoredModal();
builder.Services.AddScoped<SubscribeRepository>();

builder.Services.AddDbContext<ApplicationDbContext>(opt =>
{
    opt.UseMySql(connectionString,ServerVersion.AutoDetect(connectionString));
});

builder.Services.AddScoped<DbInitializer>();
builder.Services.AddIdentity<IdentityUser, IdentityRole>().AddEntityFrameworkStores<ApplicationDbContext>() ;
builder.Services.AddMudServices();
builder.Services.AddScoped<ProtectedSessionStorage>();
builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthenticationStateProvider>();
builder.Services.AddBlazoredToast();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}


app.UseHttpsRedirection();
app.UseStaticFiles();
app.Services.CreateScope().ServiceProvider.GetRequiredService<DbInitializer>().Initalize();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.MapBlazorHub();
app.MapFallbackToPage("/_Host");
app.Run();
