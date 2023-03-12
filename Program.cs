using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using CodeVixensTest.Data;
using CodeVixensTest.Areas.Identity.Data;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("CodeVixensTestContextConnection") ?? throw new InvalidOperationException("Connection string 'CodeVixensTestContextConnection' not found.");

builder.Services.AddDbContext<CodeVixensTestContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddDefaultIdentity<Users>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<CodeVixensTestContext>();

// Add services to the container.
builder.Services.AddRazorPages();

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

app.UseRouting();
app.UseAuthentication();;

app.UseAuthorization();

app.MapRazorPages();

app.Run();
