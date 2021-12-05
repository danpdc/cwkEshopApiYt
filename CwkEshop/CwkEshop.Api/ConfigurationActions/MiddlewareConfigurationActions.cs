using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Swashbuckle.AspNetCore.SwaggerUI;

namespace CwkEshop.Api.ConfigurationActions
{
    public static class MiddlewareConfigurationActions
    {
        public static SwaggerUIOptions ConfigureSwaggerMiddleware(WebApplication app, SwaggerUIOptions options)
        {
            var provider = app.Services.GetRequiredService<IApiVersionDescriptionProvider>();

            foreach (var description in provider.ApiVersionDescriptions)
            {
                options.SwaggerEndpoint(
                        $"/swagger/{description.GroupName}/swagger.json",
                        description.ApiVersion.ToString()
                    );
            }

            return options;
        }
    }
}
