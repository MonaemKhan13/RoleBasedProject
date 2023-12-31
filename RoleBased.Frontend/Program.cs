using Newtonsoft.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddControllersWithViews().AddNewtonsoftJson(x =>
{
    x.SerializerSettings.Formatting = Newtonsoft.Json.Formatting.Indented; // formate json with C# model
    x.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver(); // resolve camalecase and pascale case issue
    x.SerializerSettings.NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore; // ignore null values
});

var baseUrl = builder.Configuration.GetValue<string>("APIAddress");
builder.Services.AddHttpClient("Address", c =>
{
    c.BaseAddress = new Uri(baseUrl!);
});

var app = builder.Build();

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
    name: "default",
    pattern: "{controller=FrontEndLoginDb}/{action=Login}");

app.Run();
