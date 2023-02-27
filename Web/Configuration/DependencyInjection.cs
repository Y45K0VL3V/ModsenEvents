﻿using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.DB.Contexts;
using Infrastructure.DB.Repositories;
using Mapster;
using MapsterMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using TinyHelpers.Extensions;
using Web.Configuration.ServiceInstallers;

namespace Web.Configuration
{
    public static class DependencyInjection
    {
        public static IServiceCollection InstallServices(
            this IServiceCollection services, 
            IConfiguration configuration,
            params Assembly[] assemblies) 
        {
            IEnumerable<IServiceInstaller> serviceInstallers = assemblies
                .SelectMany(a => a.DefinedTypes)
                .Where(IsAssignableToType<IServiceInstaller>)
                .Select(Activator.CreateInstance)
                .Cast<IServiceInstaller>();

            serviceInstallers.ForEach(installer => installer.Install(services, configuration));

            return services;

            static bool IsAssignableToType<T>(TypeInfo typeInfo) => 
                typeof(T).IsAssignableFrom(typeInfo) &&
                !typeInfo.IsInterface &&
                !typeInfo.IsAbstract;
        }
    }
}