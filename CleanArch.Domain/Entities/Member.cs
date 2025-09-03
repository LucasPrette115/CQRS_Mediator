using CleanArch.Domain.Entities.Validation;
using CleanArch.Domain.Helpers;

namespace CleanArch.Domain.Entities;

public sealed class Member : Entity
{
    public string? FirstName { get; private set; }
    public string? LastName { get; private set; }
    public string? Email { get; private set; }
    public string? Gender { get; private set; }
    public bool? IsActive { get; private set; }   
    
    public Member(string? firstName, string? lastName, string? email, string? gender, bool? isActive)
    {
        ValidateDomain(firstName, lastName, email, gender, isActive);
    }

    public Member(Guid id, string? firstName, string? lastName, string? email, string? gender, bool? isActive)
    {
        DomainValidation.When(id == Guid.Empty, "Invalid Id");
        Id = id;
        ValidateDomain(firstName, lastName, email, gender, isActive);
    }

    public void Delete()
    {
        IsActive = false;
        DeletedAt = DateTime.Now;
    }



    private void ValidateDomain(string? firstName, string? lastName, string? email, string? gender, bool? isActive)
    {
        DomainValidation.When(string.IsNullOrEmpty(firstName), "First name is required.");
        DomainValidation.When(string.IsNullOrEmpty(lastName), "Last name is required.");
        EmailValidator.IsValid(email);
        DomainValidation.When(string.IsNullOrEmpty(gender), "Gender is required.");
        DomainValidation.When(!isActive.HasValue, "Member must be active or inactive");

        FirstName = firstName;
        LastName = lastName;
        Email = email;
        Gender = gender;
        IsActive = isActive;
    }
}