﻿using Microsoft.Build.Locator;
using Microsoft.Extensions.DependencyInjection;

namespace DotNet.CodeAnalysis
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddDotNetCodeAnalysisServices(
            this IServiceCollection services)
        {
            MSBuildLocator.RegisterDefaults();

            return services.AddSingleton<ProjectLoader>()
                .AddSingleton<ProjectWorkspace>();
        }
    }
}
