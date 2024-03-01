namespace Example.Domain.Members;

public class Member
{
    public Guid Id { get; init; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public bool IsAttending { get; set; }
}