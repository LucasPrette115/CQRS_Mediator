using Mediator.Extensions;
using Microsoft.Extensions.DependencyInjection;

namespace CleanArch.Application.Extensions
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddMediator(typeof(DependencyInjection).Assembly);
            return services;
        }
    }
}
