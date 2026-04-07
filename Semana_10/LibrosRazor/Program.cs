var builder = WebApplication.CreateBuilder(args);

// Habilita el uso de Razor Pages
builder.Services.AddRazorPages();

// Registra HttpClient para consumir la API de LibrosAPI
builder.Services.AddHttpClient("LibrosAPI", cliente =>
{
    cliente.BaseAddress = new Uri("http://localhost:5169/");
});

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthorization();

app.MapStaticAssets();
app.MapRazorPages()
    .WithStaticAssets();

app.Run();