using Catalog.API.Products.CreateProduct;
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCarter(configurator: c =>
{
    c.WithModule<CreateProductEndpoint>();
});

builder.Services.AddMediatR(config =>
{
    config.RegisterServicesFromAssembly(typeof(Program).Assembly);
});
var app = builder.Build();

app.MapCarter();
app.Run();
