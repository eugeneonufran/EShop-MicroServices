var builder = WebApplication.CreateBuilder(args);

//add services
var app = builder.Build();

//configure http pipeline

app.Run();
