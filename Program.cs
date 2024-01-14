using FeedbackApp.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<FeedbackAppContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("FeedbackAppContext") ?? throw new InvalidOperationException("Connection string 'FeedbackAppContext' not found."),
        sqlServerOptions => sqlServerOptions.EnableRetryOnFailure()));

builder.Services.AddDbContext<FeedbackAppIdentityContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("FeedbackAppIdentityContextConnection") ?? throw new InvalidOperationException("Connection string 'FeedbackAppIdentityContextConnection' not found.")));

builder.Services.AddDefaultIdentity<IdentityUser>(options =>
    options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<FeedbackAppIdentityContext>();

builder.Services.AddRazorPages();

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



