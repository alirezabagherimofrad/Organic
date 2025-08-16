using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Organic.Infrastructure
{
    public static class IocManagement
    {
        private static IServiceCollection _services;

        public static void Initialize(IServiceCollection services)
        {
            _services = services ?? throw new ArgumentNullException(nameof(services));
        }

        public static void Register<TService, TImplementation>(ServiceLifetime lifetime)
            where TService : class
            where TImplementation : class, TService
        {
            switch (lifetime)
            {
                case ServiceLifetime.Singleton:
                    _services.AddSingleton<TService, TImplementation>();
                    break;
                case ServiceLifetime.Scoped:
                    _services.AddScoped<TService, TImplementation>();
                    break;
                case ServiceLifetime.Transient:
                    _services.AddTransient<TService, TImplementation>();
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(lifetime), lifetime, null);
            }
        }

        public static void RegisterAllRepositories<TInterface>(ServiceLifetime lifetime, Assembly assembly)
        {
            // دریافت تمام کلاس‌های غیر abstract که اینترفیس TInterface را پیاده کرده‌اند
            var types = assembly.GetTypes()
                .Where(t => !t.IsAbstract && typeof(TInterface).IsAssignableFrom(t));

            foreach (var implType in types)
            {
                // پیدا کردن اینترفیس‌هایی که این کلاس پیاده کرده و از TInterface مشتق شده‌اند
                var serviceInterface = implType.GetInterfaces()
                    .FirstOrDefault(i => i != typeof(TInterface) && typeof(TInterface).IsAssignableFrom(i))
                    ?? typeof(TInterface);

                // ثبت سرویس با توجه به نوع lifetime
                switch (lifetime)
                {
                    case ServiceLifetime.Singleton:
                        _services.AddSingleton(serviceInterface, implType);
                        break;
                    case ServiceLifetime.Scoped:
                        _services.AddScoped(serviceInterface, implType);
                        break;
                    case ServiceLifetime.Transient:
                        _services.AddTransient(serviceInterface, implType);
                        break;
                    default:
                        throw new ArgumentOutOfRangeException(nameof(lifetime), lifetime, null);
                }
            }
        }
    }
}