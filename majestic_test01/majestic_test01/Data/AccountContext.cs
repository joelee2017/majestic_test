using majestic_test01.Models;
using Microsoft.EntityFrameworkCore;

namespace majestic_test01.Data
{
    public class AccountContext: DbContext
    {
        public AccountContext(DbContextOptions<AccountContext> options)
            : base(options)
        {
        }

        public DbSet<Account> Accounts { get; set; }

        public DbSet<Member> Members { get; set; }
    }
}
