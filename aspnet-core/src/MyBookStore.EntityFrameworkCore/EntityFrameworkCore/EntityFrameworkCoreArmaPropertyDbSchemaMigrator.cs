using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MyBookStore.Data;
using Volo.Abp.DependencyInjection;

namespace MyBookStore.EntityFrameworkCore;

public class EntityFrameworkCoreArmaPropertyDbSchemaMigrator
    : IArmaPropertyDbSchemaMigrator, ITransientDependency
{
    private readonly IServiceProvider _serviceProvider;

    public EntityFrameworkCoreArmaPropertyDbSchemaMigrator(
        IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public async Task MigrateAsync()
    {
        /* We intentionally resolve the MyBookStoreDbContext
         * from IServiceProvider (instead of directly injecting it)
         * to properly get the connection string of the current tenant in the
         * current scope.
         */

        await _serviceProvider
            .GetRequiredService<ArmaPropertyDbContext>()
            .Database
            .MigrateAsync();
    }
}
