﻿using CashFlow.Infrastructure.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace CashFlow.Infrastructure.Migrations;

public static class DatabaseMigration
{
    public static async Task MigrateDatabase(IServiceProvider provider)
    {
        var dbContext = provider.GetRequiredService<CashFlowDbContext>();
        await dbContext.Database.MigrateAsync();
    }
}
