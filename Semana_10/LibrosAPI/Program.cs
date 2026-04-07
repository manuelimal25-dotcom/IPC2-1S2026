using LibrosAPI.Servicio;

var builder = WebApplication.CreateBuilder(args);

// Habilita el uso de Controllers en la aplicación
builder.Services.AddControllers();

// Registra LibroServicio como singleton para inyección de dependencias
// Singleton: una sola instancia compartida durante toda la vida de la aplicación
builder.Services.AddSingleton<LibroServicio>();

var app = builder.Build();

// Redirige automáticamente las peticiones HTTP a HTTPS
app.UseHttpsRedirection();

// Habilita el middleware de autorización
app.UseAuthorization();

// Mapea las rutas definidas en los Controllers
app.MapControllers();

// Inicia la aplicación y comienza a escuchar peticiones
app.Run();