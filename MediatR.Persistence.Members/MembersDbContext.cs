using MediatR.Domain.Members;
using Microsoft.EntityFrameworkCore;

namespace MediatR.Persistence.Members;

public class MembersDbContext : DbContext
{
    public MembersDbContext(DbContextOptions<MembersDbContext> options) : base(options)
    {
        // Empty
    }
    
    public DbSet<Member> Members { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Not used by in-memory database since there are no migrations.
        // modelBuilder.Entity<Member>()
        //     .HasData(Seeding.GetMembersToSeed());
    }
}