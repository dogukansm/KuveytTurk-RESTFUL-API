using KuveytTurk.ENTITIES.Concrete;
using KuveytTurk.ENTITIES.Helper;
using Microsoft.EntityFrameworkCore;

namespace KuveytTurk.DATAACCESS.Concrete.EntityFramework.Context;

public class BankContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql(EnvHelper.ConnectionString, (e) => { e.EnableRetryOnFailure(); });
        optionsBuilder.EnableSensitiveDataLogging();
    }
    
    DbSet<BankAccountTransactions> BankAccountTransactions { get; set; }
}