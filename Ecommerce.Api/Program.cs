using Ecommerce.Application.Extentions;
using Ecommerce.Infrastructure.Extentions;
using Ecommerce.Infrastructure.Persistence;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddInfrastructure(builder.Configuration); // Extentions
builder.Services.AddApplication();



builder.Services.AddControllers();
builder.Services.AddOpenApi();
builder.Services.AddSwaggerGen(); // basic; see “Extras” below for options
var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
        policy =>
        {
            policy.WithOrigins("http://localhost:4200") // Angular app URL
                  .AllowAnyHeader()
                  .AllowAnyMethod();
        });
});
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
app.UseCors(MyAllowSpecificOrigins);
app.MapControllers();

app.Run();
