using ComicsShop.Rest.Mappers;
using ComicsShop.Rest.Services;
using ComicsShop.Rest.Entities;

namespace ComicsShop.Rest.Endpoints;

public static class ComicsModule
{
    public static void AddComicsService(this IServiceCollection service)
    {
        service.AddScoped<IComicsService, ComicsService>();
        service.AddScoped<IComicsMapper, ComicsMapper>();
    }
}