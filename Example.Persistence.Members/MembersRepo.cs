﻿using Example.Domain.Members;
using Example.Persistence.Members.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Example.Persistence.Members;

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

    public async Task<Member> GetMemberAsync(Guid memberId, CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();
        
        var member = await _context.Members.FindAsync([memberId], cancellationToken);
        
        if (member is null)
        {
            throw new KeyNotFoundException($"No member with an id of '{memberId}' found");
        }

        return member;
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