using AutoMapper;
using Microsoft.Extensions.DependencyInjection;

namespace Chat.Infra.IoC.AutoMapper
{
    public static class AutoMapperExtensions
    {
        public static IServiceCollection AddAutoMapper(this IServiceCollection services)
        {
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new ChatMappingProfile());
            });

            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);

            return services;
        }
    }
}
