using FluentValidation;

namespace MediatR.ServiceLayer.Members.GetMember;

// ReSharper disable once UnusedType.Global
public class GetMemberValidator : AbstractValidator<GetMemberRequest>
{
    public GetMemberValidator()
    {
        RuleFor(request => request.MemberId)
            .NotEmpty();
    }
}