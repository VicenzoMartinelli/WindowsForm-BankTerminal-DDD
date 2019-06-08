using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Terminal.Data.Config
{
  public class Config : DbMigrationsConfiguration<TerminalContext>
  {
    public Config()
    {
      AutomaticMigrationsEnabled = true;
      ContextKey                 = "Terminal.Data.TerminalContext ";
    }

    protected override void Seed(TerminalContext context)
    {
      
    }
  }
}
