using Ecommerce.Infrastructure.Extentions;
using Ecommerce.Infrastructure.Persistence;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddInfrastructure(builder.Configuration); // Extentions

builder.Services.AddControllers();
builder.Services.AddOpenApi();
builder.Services.AddSwaggerGen(); // basic; see “Extras” below for options
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}
app.MapGet("/products-test", (EcomerceContext db) =>
{
    var products = db.Products.ToList();
    return new { message = "Db OK", products = products };
});
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
