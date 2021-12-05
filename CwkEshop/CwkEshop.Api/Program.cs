using CwkEshop.Api.ConfigurationActions;
using CwkEshop.Api.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.RegisterServices(typeof(Program));

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI(options => MiddlewareConfigurationActions.ConfigureSwaggerMiddleware(app, options));

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
