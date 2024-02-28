using MediatR.Domain.Members;

namespace MediatR.Persistence.Members;

public static class Seeding
{
    public static IEnumerable<Member> GetMembersToSeed()
    {
        var members = new List<Member>
        {
            new()
            {
                Id = Guid.Parse("4d5d8f0c-410b-4b9b-b105-2515f64a829b"),
                FirstName = "John",
                LastName = "Smith",
                IsAttending = false
            },
            new()
            {
                Id = Guid.Parse("e5637561-8ef0-4cb9-990f-0bb8ce5bbac8"),
                FirstName = "Jane",
                LastName = "Doe",
                IsAttending = false
            }
        };

        return members;
    }
}