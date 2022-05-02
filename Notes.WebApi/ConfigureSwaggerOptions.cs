using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.SwaggerGen;
using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Mvc.ApiExplorer;

namespace Notes.WebApi
{
    public class ConfigureSwaggerOptions : IConfigureOptions<SwaggerGenOptions>
    {
        private readonly IApiVersionDescriptionProvider _provider;

        public ConfigureSwaggerOptions(IApiVersionDescriptionProvider provider)=>
            _provider = provider;

        public void Configure(SwaggerGenOptions options)
        {
            foreach(var description in _provider.ApiVersionDescriptions)
            {
                var apiVersion = description.ApiVersion.ToString();
                options.SwaggerDoc(description.GroupName,
                    new OpenApiInfo
                    {
                        Version = apiVersion,
                        Title = $"Notes API {apiVersion}",
                        Description = "A simple example ASP NET Core Web API. Professional way",
                        /*Contact = new OpenApiContact
                        {
                            Name = " Platinum Chat",
                            Email = String.Empty,
                            Url = new Uri("https://t.me/platinum_chat"),

                        },
                        License = new OpenApiLicense
                        {
                            Name = "Platinum Telegram Channel",
                            Url = new Uri("https://t.me/platinum_tech_talks")
                        }*/
                    });

                options.CustomOperationIds(apiDescription => apiDescription.TryGetMethodInfo
                (out MethodInfo methodInfo)
                ? methodInfo.Name
                : null);
            }
        }

    }
}
