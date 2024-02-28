using System;
using System.Threading.Tasks;
using FluentValidation.TestHelper;
using MediatR.ServiceLayer.MemberAttendance.UpdateAttendance;

namespace MediatR.ServiceLayer.Members.Tests.UpdateAttendance;

public class UpdateAttendanceValidatorTest
{
    private readonly UpdateAttendanceValidator _validator = new();

    [Fact]
    public async Task GetMemberValidator_WhenMemberIdIsPresent_ShouldReturnNoError()
    {
        var model = new UpdateAttendanceRequest(Guid.NewGuid());
        var result = await _validator.TestValidateAsync(model);
        
        result
            .ShouldNotHaveAnyValidationErrors();
    }
    
    [Fact]
    public async Task GetMemberValidator_WhenMemberIdIsNullOrEmpty_ShouldReturnError()
    {
        var model = new UpdateAttendanceRequest(Guid.Empty);
        var result = await _validator.TestValidateAsync(model);
        
        result
            .ShouldHaveValidationErrorFor(x => x.MemberId)
            .WithErrorMessage("'Member Id' must not be empty.");
    }
}