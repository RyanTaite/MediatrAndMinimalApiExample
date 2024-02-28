using MediatR.Domain.Members;
using MediatR.Persistence.Members.Interfaces;
using MediatR.ServiceLayer.Members.Interfaces;

namespace MediatR.ServiceLayer.Members;

public class MembersService : IMembersService
{
    private readonly IMembersRepo _membersRepo;

    public MembersService(IMembersRepo membersRepo)
    {
        _membersRepo = membersRepo;
    }
    
    public async Task<List<Member>> GetAllMembersAsync(CancellationToken cancellationToken)
    {
        return await _membersRepo.GetAllMembersAsync(cancellationToken);
    }

    public async Task<Member> GetMemberAsync(Guid memberId, CancellationToken cancellationToken)
    {
        return await _membersRepo.GetMemberAsync(memberId, cancellationToken);
    }
}