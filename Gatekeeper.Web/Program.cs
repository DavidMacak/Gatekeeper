using GatekeeperLib.Data;
using GatekeeperLib.Databases;
using Microsoft.Extensions.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

// Výbìr typu SQL databáze
string dbChoice = builder.Configuration.GetValue<string>("DatabaseChoice").ToLower();
if(dbChoice == "sql")
{
    builder.Services.AddTransient<IDatabaseData, SqlData>();
}
else if(dbChoice == "sqlite")
{
    throw new NotImplementedException();
    //builder.Services.AddTransien<IDatabaseData, SqliteData>();
}
else
{
    builder.Services.AddTransient<IDatabaseData, SqlData>();
}

builder.Services.AddTransient<ISqlDataAccess, SqlDataAccess>();
//builder.Services.AddTransient<ISqliteDataAccess, SqliteDataAccess>();

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
app.UseAuthorization();
app.MapRazorPages();
app.Run();
