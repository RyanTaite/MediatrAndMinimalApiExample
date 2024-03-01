using Example.Domain.Members;
using Example.Persistence.Members.Interfaces;
using Example.ServiceLayer.Members.Interfaces;

namespace Example.ServiceLayer.Members;

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