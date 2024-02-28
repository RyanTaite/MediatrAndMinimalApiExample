using FluentValidation;

namespace MediatR.ServiceLayer.MemberAttendance.UpdateAttendance;

// ReSharper disable once UnusedType.Global
public class UpdateAttendanceValidator : AbstractValidator<UpdateAttendanceRequest>
{
    public UpdateAttendanceValidator()
    {
        RuleFor(updateAttendanceRequest => 
                updateAttendanceRequest.MemberId)
            .NotEmpty();
    }
}