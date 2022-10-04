using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using School.UIBlazor.Contracts;
using School.UIBlazor.Data;
using School.UIBlazor.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton<WeatherForecastService>();

builder.Services.AddHttpClient<IStudentsService, StudentsService>(
    client => client.BaseAddress = new Uri("http://localhost:5132")
    );
builder.Services.AddHttpClient<ICountryService, CountryService>(
    client => client.BaseAddress = new Uri("http://localhost:5132")
    );


var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}

app.UseStaticFiles();
app.UseRouting();
app.MapBlazorHub();
app.MapFallbackToPage("/_Host");
app.Run();
