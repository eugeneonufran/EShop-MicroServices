var builder = WebApplication.CreateBuilder(args);

var assembly = typeof(Program).Assembly;

builder.Services.AddCarter(configurator: c =>
{
    c.WithModule<GetBasketEndpoints>();
    c.WithModule<DeleteBasketEndpoints>();
    c.WithModule<StoreBasketEndpoints>();
});

builder.Services.AddMediatR(config =>
{
    config.RegisterServicesFromAssembly(assembly);
    config.AddOpenBehavior(typeof(ValidationBehaviour<,>));
    config.AddOpenBehavior(typeof(LoggingBehaviour<,>));
});

builder.Services.AddValidatorsFromAssembly(assembly);

var app = builder.Build();

app.MapCarter();

app.Run();
