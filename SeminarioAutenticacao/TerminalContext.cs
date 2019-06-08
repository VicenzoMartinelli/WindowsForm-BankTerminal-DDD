using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terminal.Domain.Core;
using static System.Data.Entity.Migrations.Model.UpdateDatabaseOperation;

namespace Terminal.Data
{
  public class TerminalContext : DbContext
  {
    public TerminalContext()
        : base("name=ProjetoFinal")
    {
      Database.SetInitializer(new MigrateDatabaseToLatestVersion<TerminalContext, Config.Config>());
    }

    protected override void OnModelCreating(DbModelBuilder builder)
    {
      base.OnModelCreating(builder);

    }
    public override int SaveChanges()
    {
      AddLogAttributes();
      return base.SaveChanges();
    }

    public override async Task<int> SaveChangesAsync()
    {
      AddLogAttributes();
      return await base.SaveChangesAsync();
    }

    private void AddLogAttributes()
    {
      var entities = ChangeTracker.Entries()
          .Where(x => x.Entity is EntityBase && (x.State == EntityState.Added || x.State == EntityState.Modified));

      foreach (var entity in entities)
      {
        if (entity.State == EntityState.Added)
        {
          (entity.Entity as EntityBase).DataCriacao = DateTime.UtcNow;
        }

        (entity.Entity as EntityBase).DataAlteracao = DateTime.UtcNow;
      }
    }
  }
}
