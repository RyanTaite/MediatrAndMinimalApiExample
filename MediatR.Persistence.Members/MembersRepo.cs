using MediatR.Domain.Members;
using MediatR.Persistence.Members.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace MediatR.Persistence.Members;

public class MembersRepo : IMembersRepo
{
    private readonly MembersDbContext _context;

    public MembersRepo(MembersDbContext membersDbContext)
    {
        _context = membersDbContext;
        
        PopulateInMemoryDatabase();
    }

    public async Task<List<Member>> GetAllMembersAsync()
    {
        return await _context
            .Members
            .ToListAsync();
    }

    public Task<List<Member>> GetAllMembersAsync(CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();

        return _context.Members.ToListAsync(cancellationToken);
    }

    public async Task<bool> ToggleMembersAttendanceAsync(Guid memberId, CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();
        
        var memberToUpdate = await _context.Members.FindAsync([memberId], cancellationToken: cancellationToken);
        
        if (memberToUpdate is null)
        {
            throw new KeyNotFoundException($"No member with an id of '{memberId}' found");
        }
        
        memberToUpdate.IsAttending = !memberToUpdate.IsAttending;

        await _context.SaveChangesAsync(cancellationToken);

        return memberToUpdate.IsAttending;
    }
    
    /// <summary>
    /// Since we are using an in-memory database, this method will populate the database
    /// with some hard-coded values for us.
    /// </summary>
    private void PopulateInMemoryDatabase()
    {
        var doesAnyDataExist = _context.Members.Any();
        
        if (doesAnyDataExist) return;
        
        _context.AddRange(Seeding.GetMembersToSeed());
        _context.SaveChanges();
    }
}