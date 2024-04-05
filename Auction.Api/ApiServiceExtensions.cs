using Microsoft.Extensions.DependencyInjection;

namespace AuctionApi;

public static class ApiServiceExtensions
{
    public static void AddApi(this IServiceCollection services)
    {
        services.AddControllers();
    }
}