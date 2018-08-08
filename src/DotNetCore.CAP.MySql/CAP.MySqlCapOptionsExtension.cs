﻿// Copyright (c) .NET Core Community. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using DotNetCore.CAP.MySql;
using DotNetCore.CAP.Processor;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

// ReSharper disable once CheckNamespace
namespace DotNetCore.CAP
{
    internal class MySqlCapOptionsExtension : ICapOptionsExtension
    {
        private readonly Action<MySqlOptions> _configure;

        public MySqlCapOptionsExtension(Action<MySqlOptions> configure)
        {
            _configure = configure;
        }

        public void AddServices(IServiceCollection services)
        {
            services.TryAddSingleton<CapDatabaseStorageMarkerService>();
            services.TryAddSingleton<IStorage, MySqlStorage>();
            services.TryAddSingleton<IStorageConnection, MySqlStorageConnection>();
            services.TryAddScoped<ICapPublisher, CapPublisher>();
            services.TryAddScoped<ICallbackPublisher, CapPublisher>();
            services.TryAddTransient<ICollectProcessor, MySqlCollectProcessor>();

            AddSingletionMySqlOptions(services);
        }

        private void AddSingletionMySqlOptions(IServiceCollection services)
        {
            var mysqlOptions = new MySqlOptions();

            _configure(mysqlOptions);

            if (mysqlOptions.DbContextType != null)
            {
                services.TryAddSingleton(x =>
                {
                    using (var scope = x.CreateScope())
                    {
                        var provider = scope.ServiceProvider;
                        var dbContext = (DbContext)provider.GetService(mysqlOptions.DbContextType);
                        mysqlOptions.ConnectionString = dbContext.Database.GetDbConnection().ConnectionString;
                        return mysqlOptions;
                    }
                });
            }
            else
            {
                services.TryAddSingleton(mysqlOptions);
            }
        }
    }
}