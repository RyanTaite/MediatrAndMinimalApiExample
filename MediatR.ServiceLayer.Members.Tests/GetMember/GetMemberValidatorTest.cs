using System;
using System.Threading.Tasks;
using FluentValidation.TestHelper;
using MediatR.ServiceLayer.Members.GetMember;

namespace MediatR.ServiceLayer.Members.Tests.GetMember;

public class GetMemberValidatorTest
{
    private readonly GetMemberValidator _validator = new();

    [Fact]
    public async Task GetMemberValidator_WhenMemberIdIsPresent_ShouldReturnNoError()
    {
        var model = new GetMemberRequest(Guid.NewGuid());
        var result = await _validator.TestValidateAsync(model);
        
        result
            .ShouldNotHaveAnyValidationErrors();
    }
    
    [Fact]
    public async Task GetMemberValidator_WhenMemberIdIsNullOrEmpty_ShouldReturnError()
    {
        var model = new GetMemberRequest(Guid.Empty);
        var result = await _validator.TestValidateAsync(model);
        
        result
            .ShouldHaveValidationErrorFor(x => x.MemberId)
            .WithErrorMessage("'Member Id' must not be empty.");
    }
}