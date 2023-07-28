
namespace API.Extension;

public static class ApplicationServiceExtension
{
    // * ----- Metodo Configuracion de las Cors -----
    public static void ConfigureCors(this IServiceCollection services) =>
        services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy", builder =>
                    builder.AllowAnyOrigin()   //WithOrigins("https://domini.com")
                    .AllowAnyMethod()          //WithMethods(*GET ", "POST")
                    .AllowAnyHeader()          //WithHeaders(*accept*, "content-type")
                );

            }
    );
}
