using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore;
using rentalmovie.Models;


public class SQLDbContext: DbContext
{
    public SQLDbContext(DbContextOptions<SQLDbContext> options) : base(options)
    {

    }
    public DbSet<Register> Registers { get; set; }
    public DbSet<MembershipType> MembershipTypes { get; set; }
    public DbSet<Customers> Customerss { get; set; }
    public DbSet<CustomerMembershipType> CustomersMembershipType { get; set; }


}